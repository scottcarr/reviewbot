﻿/*
  ReviewBot 0.1
  Copyright (c) Microsoft Corporation
  All rights reserved. 
  
  MIT License
  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
  The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
  THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Research.ReviewBot.Utils
{
  internal static class ParseCommandLine
  {
    static public bool TryParseCommandLine(string[] args, out Output.ToolAction action, out string configFile)
    {
      Contract.Requires(args != null);
      Contract.Ensures(!Contract.Result<bool>() || Contract.ValueAtReturn(out configFile) != null);

      configFile = null;

      if(args.Length == 0)
      {
        action = Output.ToolAction.Run;
        configFile = Constants.String.ConfigDefault;

        return true;
      }

      if(args.Length == 1)
      {
        if (args[0].ToLower() == "-createdefaultconfig")
        {
          action = Output.ToolAction.CreateDefaultFile;
        }
        else
        {
          action = Output.ToolAction.Run;
          configFile = args[0];
          Contract.Assume(configFile != null);
        }
        return true;
      }

      action = Output.ToolAction.PrintUsage;
      return false;
    }

    static public void PrintUsage()
    {
      Output.WriteLine(string.Format("Usage: {0} [config.xml] | [-CreateDefaultConfig]", Constants.String.ToolName));
    }

  }
}
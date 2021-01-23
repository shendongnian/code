    private static void cmdOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
        if (!String.IsNullOrEmpty(outLine.Data))
        {  // Add the text to the collected output.
            cmdOutput.Append(Environment.NewLine + outLine.Data);
        }
    }
    private static void cmdErrorDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
        if (!String.IsNullOrEmpty(outLine.Data))
        {  // Add the text to the collected error output.
            cmdErrOutput.Append(Environment.NewLine + outLine.Data);
        }
    }
        

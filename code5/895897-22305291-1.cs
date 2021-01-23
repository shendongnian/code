    startinfo.OutputDataReceived += DOSOutputResultsHandler;
    
    StringBuilder DOSOutputResults = new StringBuilder();
    
    
    protected void DOSOutputResultsHandler(object sendingProcess,
       System.Diagnostics.DataReceivedEventArgs outLine)
    {
       if (!string.IsNullOrEmpty(outLine.Data))
          // track data into the NORMAL output string builder
          DOSOutputResults.Append(Environment.NewLine + outLine.Data);
    }

    StringBuilder DOSOutputResults = new StringBuilder();
    StringBuilder DOSOutputErrors = new StringBuilder();
    
    
    protected void DOSOutputResultsHandler(object sendingProcess,
       System.Diagnostics.DataReceivedEventArgs outLine)
    {
       if (!string.IsNullOrEmpty(outLine.Data))
          // track data into the NORMAL output string builder
          DOSOutputResults.Append(Environment.NewLine + outLine.Data);
    }
    
    
    protected void DOSOutputErrorsHandler(object sendingProcess,
       System.Diagnostics.DataReceivedEventArgs outLine)
    {
       if (!String.IsNullOrEmpty(outLine.Data))
          // track data into the ERROR output string builder
          DOSOutputErrors.Append(Environment.NewLine + outLine.Data);
    }

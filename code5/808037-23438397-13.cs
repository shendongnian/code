    public override void Write(string message)
    {
        // Call write line
        WriteLine(message);
    }
    public override void WriteLine(string message)
    {
        if (enabled)
        {
            //see: http://stackoverflow.com/questions/19817655/
            if (message.StartsWith("System.ServiceModel Error: 131075"))
            {
                //this is the first of two messages that will be sent for this error ... 
                //we'll count up the number of times we've seen it
                ++num131075errors;
            }
            else if (message.EndsWith("2746</NativeErrorCode></Exception></TraceRecord>"))
            {
                //this is the second of 2 messages for the "Safe to ignore" 131075 error
                //techincally its possible that this same message would be sent for a different error, so
                //log it instead of strictly ignoring it ... we'll add the current "count" for the times
                //we've ignored the "Service Model Error" message, so we can detect if this error did or 
                //did not come from the "usual" service model safe-to-ignore error
                log.Debug("Remote host forcibly closed connection (ServiceModelError 131075, NativeErrorCod 2746) x" + num131075errors);
            }
            else
                log.Debug(">> " + message);
        }
    }

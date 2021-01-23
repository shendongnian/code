    public void LogTrace(String message, params object[] parameters)
    {
        if(parameters != null && parameters.Length > 0)
            var s = String.Format(message, Parameters);
        else
            var s = message;
        // do something with s
    }

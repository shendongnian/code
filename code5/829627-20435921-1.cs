    public override String ToString()
    {
        String message = Message;
        String s;
 
        if (message == null || message.Length <= 0)
            s = GetClassName();
        else
            s = GetClassName() + ": " + message;
 
        if (_innerException != null)
            s = s + " ---> " + _innerException.ToString(needFileLineInfo, needMessage) + Environment.NewLine + 
            "   " + Environment.GetResourceString("Exception_EndOfInnerExceptionStack");
 
        string stackTrace = GetStackTrace(needFileLineInfo);
        if (stackTrace != null)
            s += Environment.NewLine + stackTrace;
 
        return s;
    }

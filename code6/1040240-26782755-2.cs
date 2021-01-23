    [DebuggerHidden, DebuggerStepThrough]
    public static void ArgumentNotNull(object argument, [CallerMemberName] string callerName = "")
    {
        //callerName  should be the thing you want 
        if (argument == null)
        {
            throw new ArgumentNullException(name, "Cannot be null");
        }
    }

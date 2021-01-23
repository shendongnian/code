    public static void Log(string message, Exception exception = null)
    {
        var method = new StackFrame(1).GetMethod();
        // get caller name, so that you don't need to specify it, when calling Log()
        var caller = method.DeclaringType.Name + "." + method.Name;
        ...
    }

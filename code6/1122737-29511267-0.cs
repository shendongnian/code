    public static void PrintCallerClassType()
    {
        var stackTrace = new StackTrace(new StackFrame(1));
        var frame = stackTrace.GetFrame(0);
        Console.WriteLine(frame.GetMethod().DeclaringType);
    }

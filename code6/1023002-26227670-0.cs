    static void WriteLine(string message)
    {
        StackFrame callStack = new StackFrame(1, true);
        var lineNumber = callStack.GetFileLineNumber();
        Console.WriteLine(lineNumber + ": " + message);
    }

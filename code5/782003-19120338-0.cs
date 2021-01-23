    [Conditional("DEBUG")]
    public static void WriteLine(string message, string category)
    {
    	TraceInternal.WriteLine(message, category);
    }

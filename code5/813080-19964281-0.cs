    public static void Log(string text)
    {
        ConsoleTraceListener listener = new ConsoleTraceListener();
        Trace.Listeners.Add(listener);
        Trace.WriteLine(text);
        Trace.Listeners.Remove(listener);
        Trace.Close();
    }

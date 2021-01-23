    public static object GetValue([CallerMemberName] string caller = "")
    {
        Trace.WriteLine("Called by: " + caller);
        return null;
    }

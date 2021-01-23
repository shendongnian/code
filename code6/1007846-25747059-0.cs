    [Conditional("RELEASE")]
    public static void AssertRelease(bool condition)
    {
        Trace.Assert(condition);
    }

    static IDisposable Measure
    {
        get
        {
            // before behavior
            return new TimerHandle( /* timing/after behavior */);
        }
    }
    using (Measure) { a; b; c; }
    using (Measure) { d; e; f; }

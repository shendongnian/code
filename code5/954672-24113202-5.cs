    static IDisposable Measure
    {
        get
        {
            // before behavior
            return new TimerHandle(time => {
                // timing behavior
                // after behavior
            });
        }
    }
    using (Measure) { doLotsOfStuff(); }
    using (Measure) { andOtherStuff(); }

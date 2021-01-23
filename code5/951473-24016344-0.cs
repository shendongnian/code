    [__DynamicallyInvokable]
    public long Ticks
    {
        [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get
        {
            return this.InternalTicks;
        }
    }
    [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public static bool operator >(DateTime t1, DateTime t2)
    {
        return t1.InternalTicks > t2.InternalTicks;
    }

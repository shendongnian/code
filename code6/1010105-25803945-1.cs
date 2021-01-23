    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public static bool operator < (DateTime t1, DateTime t2) {
            return t1.InternalTicks < t2.InternalTicks;
    }
 
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public static bool operator > (DateTime t1, DateTime t2) {
            return t1.InternalTicks > t2.InternalTicks;
    }

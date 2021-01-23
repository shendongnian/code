    public static DateTime UtcNow
    {
        get
        {
            return new DateTime((ulong) ((GetSystemTimeAsFileTime() + 0x701ce1722770000L) | 0x4000000000000000L));
        }
    }

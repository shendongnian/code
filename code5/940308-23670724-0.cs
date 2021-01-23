    private static final long UNIX_EPOCH = 62135596800000L;
    public static Date fromDateTimeBinary(long value) {
        // Mask off the top bits, which hold the "kind" and
        // possibly offset.
        // This is irrelevant in Java, as a Date has no
        // notion of time zone
        value = value & 0x3fffffffffffffffL;
        // A tick in .NET is 100 nanoseconds. So a millisecond
        // is 10,000 ticks.
        value = value / 10000;
        return new Date(value - UNIX_EPOCH); 
    }

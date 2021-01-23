    [Flags]
    public enum ColumnFlags
    {
        None = 0,
        Camber = 0x1,
        Rake = 0x2,
        Angle = 0x4,
        // Other optional columns here, keep them powers of 2!
    }

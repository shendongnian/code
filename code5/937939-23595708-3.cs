    [Obsolete("Use NewDouble instead.")]
    public int Double(int i)
    {
        return NewDouble(i);
    }
    public int NewDouble(int i)
    {
        return i << 1;
    }

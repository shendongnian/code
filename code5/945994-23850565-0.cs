    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsControl(char c)
    {
        return ((c >= 0 && c <= 31) || (c >= 127 && c <= 159));
    }

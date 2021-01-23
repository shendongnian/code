    public override string ToString()
    {
        return Number.FormatInt32(
        this,
        null,
        NumberFormatInfo.CurrentInfo);
    }
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern string FormatInt32(
        int value,
        string format,
        NumberFormatInfo info);

    [StructLayout(LayoutKind.Explicit)]
    public struct Rect 
    {
       [FieldOffset(0)] public int left;
       [FieldOffset(4)] public int top;
       [FieldOffset(8)] public int right;
       [FieldOffset(12)] public int bottom;
    } 

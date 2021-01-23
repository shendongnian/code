    int* test()
    {
        return &i;
    }
    [DllImport(@"lib\test.dll", CallingConvention=CallingConvention.Cdecl)]
    public static extern IntPtr test();
    
    IntPtr p = test();
    if (p == IntPtr.Zero)
        // error

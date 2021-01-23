    [DllImport(@"lib\test.dll", CallingConvention=CallingConvention.Cdecl)]
    public static extern unsafe int test(IntPtr* p);
    
    public unsafe void DotNetFunc()
    {
        IntPtr p;
        test(&p);

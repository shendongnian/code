    [DllImport("ZLIB1.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr zlibVersion();
    public static string Version 
    {
        get 
        { 
            return Marshal.PtrToStringAnsi(zlibVersion());
        } 
    }

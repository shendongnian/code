    enum Error
    {
          Error1,
          Error2,
          Error3,
    }
    [DllImport("dll_name.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void foo([MarshalAs(UnmanagedType.LPStr)] string str, ref Error err);

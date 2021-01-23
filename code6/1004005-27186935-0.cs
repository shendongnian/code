    [DllImport(@"mclmcrrt7_17.dll", EntryPoint = "mclInitializeApplication_proxy", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool mclInitializeApplication(string options, Int32 count);
    [DllImport(@"mclmcrrt7_17.dll", EntryPoint = "mclTerminateApplication_proxy", CallingConvention = CallingConvention.Cdecl)]
    private static extern void mclTerminateApplication();  
    [DllImport("libmcc.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool _mlfCreat_smallsample (int nargout, ref IntPtr sample);

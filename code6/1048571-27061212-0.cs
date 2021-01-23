    [DllImport(dllname, CallingConvention = CallingConvention.Cdecl)]
    public static extern int MRK3LINK_Open(
        LogHandlerDelegate LogHandler,
        ErrorOutHandlerDelegate ErrorOutHandler
    ); 

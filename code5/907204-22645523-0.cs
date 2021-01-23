    [DllImport("LogitechLcd.dll", CallingConvention=CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.I1)]
    public static extern bool LogiLcdInit(String friendlyName, LcdType lcdType);
    [DllImport("LogitechLcd.dll", CallingConvention=CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.I1)]
    public static extern bool LogiLcdIsConnected(LcdType lcdType);

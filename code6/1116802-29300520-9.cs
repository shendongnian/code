    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr MessageHandlerDelegate(IntPtr ptr);
    [DllImport("Win32Project1.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern void register_message_handler(MessageHandlerDelegate del);
    [DllImport("Win32Project1.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern IntPtr message_handler(IntPtr message);

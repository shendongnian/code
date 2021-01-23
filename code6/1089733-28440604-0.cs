    [DllImport("libsomething.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint AnDevice_GetList(IntPtr outdevs);
    IntPtr[] ptArray = new IntPtr[numberOfPointersRequired];
    GCHandle handle = GCHandle.Alloc(ptArray);
    try
    {
        AnDevice_GetList(handle.AddrOfPinnedObject());
    }
    finally
    {
        handle.Free();
    }

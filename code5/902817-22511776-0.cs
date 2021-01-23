    internal static class WinDbgBase
    {
    	// STDAPI DebugCreate(__in REFIID InterfaceId, __out PVOID* Interface);
    	[DllImport("dbgeng.dll", EntryPoint = "DebugCreate", CallingConvention = CallingConvention.StdCall)]
    	public static extern int DebugCreate([In] ref System.Guid InterfaceId, ref System.IntPtr Interface);
    }
    Guid uuidof_IDebugClient4 = new Guid("{ca83c3de-5089-4cf8-93c8-d892387f2a5e}");
    IntPtr pObj = IntPtr.Zero;
    int hr = WinDbgBase.DebugCreate(ref uuidof_IDebugClient4, ref pObj);
    IDebugClient4 _client = (IDebugClient4)Marshal.GetTypedObjectForIUnknown(pObj, typeof(IDebugClient4));
    
    // QueryInterface the other objects
    IDebugControl4 _control = (IDebugControl4)_client;
    
    _client.AttachProcess(0, ProcessId, DEBUG_ATTACH.DEBUG_ATTACH_DEFAULT);
    _control.WaitForEvent(DEBUG_WAIT.DEBUG_WAIT_DEFAULT, Win32.INFINITE);
    ...

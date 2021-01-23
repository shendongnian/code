    public partial class NativeMethods {
        
        /// Return Type: DWORD->unsigned int
        ///dwMilliseconds: DWORD->unsigned int
        ///bAlertable: BOOL->int
        [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint="SleepEx")]
    public static extern  uint SleepEx(uint dwMilliseconds, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool bAlertable) ;
    
    }

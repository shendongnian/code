    public class MessageBoxWithTimeout
    {
      [DllImport("user32.dll", SetLastError = true)]
      [return: MarshalAs(UnmanagedType.U4)]
      private static extern uint MessageBoxTimeout(IntPtr hwnd,
        [MarshalAs(UnmanagedType.LPTStr)]  String text,
        [MarshalAs(UnmanagedType.LPTStr)] String title,
        [MarshalAs(UnmanagedType.U4)] uint type, 
        Int16 wLanguageId, 
        Int32 milliseconds);
     
      public static uint Show(IntPtr hWnd, string message, string caption, uint messageBoxOptions,Int32 timeOutMilliSeconds)
      {
         return MessageBoxTimeout(hWnd, message, caption, messageBoxOptions, 0, timeOutMilliSeconds);
      }
    }

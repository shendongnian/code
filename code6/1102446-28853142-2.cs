    public static uint GetIdleTime()
    {
         LASTINPUTINFO LastUserAction = new LASTINPUTINFO();
         LastUserAction.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(LastUserAction);
         GetLastInputInfo(ref LastUserAction);
         return ((uint)Environment.TickCount - LastUserAction.dwTime);
    }

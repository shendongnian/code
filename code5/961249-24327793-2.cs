    public class Helper
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd,
                                                    out uint lpdwProcessId);
        public static bool OwnedBySameProcess(IntPtr hWnd1, IntPtr hWnd2)
        {
            if ( !IsWindow(hWnd1) )
                throw new ArgumentException("hWnd1");
            if ( !IsWindow(hWnd2) )
                throw new ArgumentException("hWnd2");
            uint procId1 = 0;
            GetWindowThreadProcessId(hWnd1, out procId1);
            uint procId2 = 0;
            GetWindowThreadProcessId(hWnd2, out procId2);
            return ( procId1 == procId2 );
        }
    }

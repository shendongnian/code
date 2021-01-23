        public class User32Wrapper
        {
            // GetMessage
            [DllImport(@"user32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern bool GetMessage(ref MSG message, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
            [DllImport(@"user32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern bool TranslateMessage(ref MSG message);
            [DllImport(@"user32.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern long DispatchMessage(ref MSG message);
            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                long x;
                long y;
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct MSG
            {
                IntPtr hwnd;
                public uint message;
                UIntPtr wParam;
                IntPtr lParam;
                uint time;
                POINT pt;
            }
        }
        private const int WM_CUSTOM_EXIT = 0x0400 + 2000;
        private const int WM_CUSTOM_1 = 0x0400 + 2001;
        private const int WM_CUSTOM_2 = 0x0400 + 2002;
        private const int WM_CUSTOM_3 = 0x0400 + 2003;
        static void Main(string[] args)
        {
            ILog log = LogManager.GetLogger("Main");
            // running working threads
            ...
            // Main message loop
            User32Wrapper.MSG msg = new User32Wrapper.MSG();
            while (User32Wrapper.GetMessage(ref msg, IntPtr.Zero, 0, 0))
            {
                if (WM_CUSTOM_EXIT == msg.message) // add WM_CLOSE if you need
                {
                    break;
                }
                if (WM_CUSTOM_1 == msg.message)
                {
                    onWmCustom1();
                }
                //if (check_any_message_you_need == msg.message)
                // you can for example check if Enter has been pressed to emulate Console.Readline();
                User32Wrapper.TranslateMessage(ref msg);
                User32Wrapper.DispatchMessage(ref msg);
             }
            log.Info("Finished");
        }

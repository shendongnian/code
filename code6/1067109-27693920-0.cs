        //The system keyboard event.
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        public const int VK_CONTROL = 0x11; //Control key code
        public const int C = 0x43; // C key code
        public const int V = 0x56; // V key code
        static void Main(string[] args)
        {
            Thread.Sleep(1000);// So I have time to select something.
            // Simulating Ctrl+C
            keybd_event(VK_CONTROL, 0x9d, 0, 0); // Ctrl Press
            keybd_event(C, 0x9e, 0, 0); // ‘A’ Press
            keybd_event(C, 0x9e, KEYEVENTF_KEYUP, 0); // ‘A’ Release
            keybd_event(VK_CONTROL, 0x9d, KEYEVENTF_KEYUP, 0); // Ctrl Release
            // Simulating Ctrl+V
            keybd_event(VK_CONTROL, 0x9d, 0, 0); // Ctrl Press
            keybd_event(V, 0x9e, 0, 0); // ‘A’ Press
            keybd_event(V, 0x9e, KEYEVENTF_KEYUP, 0); // ‘A’ Release
            keybd_event(VK_CONTROL, 0x9d, KEYEVENTF_KEYUP, 0); // Ctrl Release
       }

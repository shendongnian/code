        [DllImport("user32")]
        private static extern IntPtr SetWindowsHookEx(int hookType, KeyboardLowLevelProc proc, IntPtr moduleHandle, int threadID);
        [DllImport("user32")]
        private static extern int UnhookWindowsHookEx(IntPtr hHook);
        [DllImport("user32")]
        private static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32")]
        private static extern IntPtr GetModuleHandle(string moduleName);
        public struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
        public delegate IntPtr KeyboardLowLevelProc(int hCode, IntPtr wParam, IntPtr lParam);
        public IntPtr KeyboardLowLevelCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0) {
                KBDLLHOOKSTRUCT kbd = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                if (kbd.key == Keys.D0 && blockD0) {                
                    if(ModifierKeys == (Keys.Control | Keys.Shift)) {
                        SendKeys.Send("{ESC}");
                        //Add custom code as the response to Ctrl + Shift + D0 here
                        //....
                    }
                    return new IntPtr(1);//Discard the default behavior
                }
            }
            return CallNextHookEx(hHook, nCode, wParam, lParam);
        }
        bool blockD0;
        KeyboardLowLevelProc proc; //this should be declared in the form scope
        IntPtr hHook;
        //your Form1 constructor
        public Form1(){
           InitializeComponent();
           //Get current module Handle
           IntPtr currentModuleHandle = GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName);
           //Set the keyboard hook
           hHook = SetWindowsHookEx(13, proc, currentModuleHandle, 0);//WH_KEYBOARD_LL = 13
           //register these Key events for your richTextBox1 
           richTextBox1.KeyDown += (s, e) => {
                if(e.KeyCode != Keys.D0) blockD0 = true;
           };
           richTextBox1.KeyUp += (s, e) => {
                if (ModifierKeys == Keys.None) blockD0 = false;
           };
           //Unhook keyboard when form is closed
           FormClosed += (s,e) => {
              if (hHook != IntPtr.Zero) {
                  UnhookWindowsHookEx(hHook);
                  hHook = IntPtr.Zero;
              }
           }
        }

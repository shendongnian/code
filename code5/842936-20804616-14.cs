        using System.Windows.Interop;
        static readonly int MyHotKeyId = 0x3000;
        static readonly int WM_HOTKEY = 0x312;
 
        void InitializeHook()
        {
            var windowHelper = new WindowInteropHelper(this);
            var windowSource = HwndSource.FromHwnd(windowHelper.Handle);
            windowSource.AddHook(MessagePumpHook);
        }
        IntPtr MessagePumpHook(IntPtr handle, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_HOTKEY)
            {
                if ((int)wParam == MyHotKeyId)
                {
                    // The hotkey has been pressed, do something!
                    handled = true;
                }
            }
            return IntPtr.Zero;
        }

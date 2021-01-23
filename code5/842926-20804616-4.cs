        using System.Windows.Interop;
        static readonly int WM_HOTKEY = 0x312;
 
        void InitializeHook()
        {
            var windowHelper = new WindowInteropHelper(this);
            var windowSource = HwndSource.FromHwnd(windowHelper.Handle);
            windowSource.AddHook(MessagePumpHook);
        }
        IntPtr MessagePumpHook(IntPtr handle, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if(msg == WM_HOTKEY)
            {
              // LPARAM has the hotkey ID!
              if((int)lParam == MyHotkeyId)
              {
                 // Do something here.
                
                 handled = true;
              }
            }
            return IntPtr.Zero;
        }

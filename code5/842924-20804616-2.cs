        using System.Windows.Interop;
        void InitializeHook()
        {
            var windowHelper = new WindowInteropHelper(this);
            var windowSource = HwndSource.FromHwnd(windowHelper.Handle);
            windowSource.AddHook(MessagePumpHook);
        }

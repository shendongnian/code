     public class WindowSecond : Window
        {
            public WindowSecond()
            {
                Owner = Application.Current.MainWindow;
                MouseDown += delegate
                    {
                        // maybe cache it.
                        IntPtr handle = new WindowInteropHelper(Owner).Handle;
    
                        EnableWindow(handle, true);
                        Application.Current.MainWindow.DragMove();
                        EnableWindow(handle, false);
                    };
            }
    
            [DllImport("user32")]
            internal static extern bool EnableWindow(IntPtr hwnd, bool bEnable);
        }

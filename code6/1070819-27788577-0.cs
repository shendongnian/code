    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SourceInitialized += OnSourceInitialized;
        }
        private void OnSourceInitialized(object sender, EventArgs eventArgs)
        {
            if (!NativeMethods.DwmIsCompositionEnabled())
                return;
            var hwnd = new WindowInteropHelper(this).Handle;
            var hwndSource = HwndSource.FromHwnd(hwnd);
            var sizeFactor = hwndSource.CompositionTarget.TransformToDevice.Transform(new Vector(1.0, 1.0));
            Background = System.Windows.Media.Brushes.Transparent;
            hwndSource.CompositionTarget.BackgroundColor = Colors.Transparent;
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, (int)(ActualWidth * sizeFactor.X), (int)(ActualHeight * sizeFactor.Y));
                using (var region = new Region(path))
                using (var graphics = Graphics.FromHwnd(hwnd))
                {
                    var hRgn = region.GetHrgn(graphics);
                    var blur = new NativeMethods.DWM_BLURBEHIND
                    {
                        dwFlags = NativeMethods.DWM_BB.DWM_BB_ENABLE | NativeMethods.DWM_BB.DWM_BB_BLURREGION | NativeMethods.DWM_BB.DWM_BB_TRANSITIONONMAXIMIZED,
                        fEnable = true,
                        hRgnBlur = hRgn,
                        fTransitionOnMaximized = true
                    };
                    NativeMethods.DwmEnableBlurBehindWindow(hwnd, ref blur);
                    region.ReleaseHrgn(hRgn);
                }
            }
        }
        [SuppressUnmanagedCodeSecurity]
        private static class NativeMethods
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct DWM_BLURBEHIND
            {
                public DWM_BB dwFlags;
                public bool fEnable;
                public IntPtr hRgnBlur;
                public bool fTransitionOnMaximized;
            }
            [Flags]
            public enum DWM_BB
            {
                DWM_BB_ENABLE = 1,
                DWM_BB_BLURREGION = 2,
                DWM_BB_TRANSITIONONMAXIMIZED = 4
            }
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern bool DwmIsCompositionEnabled();
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmEnableBlurBehindWindow(IntPtr hwnd, ref DWM_BLURBEHIND blurBehind);
        }
    }

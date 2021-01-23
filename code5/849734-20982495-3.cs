    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    public partial class ShaderControl : UserControl
    {
        //we will need all these imports, see their documentation on what they do exactly
        [DllImport("user32")]
        private static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32", EntryPoint = "SetWindowLong", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32", EntryPoint = "GetWindowLong", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        //we're going to give the window these constans as parameters
        private const int WS_EX_TOOLWINDOW = 0x80; //make it a toolwindow
        private const int WS_EX_NOACTIVATE = 0x8000000; //make it non-activating
        private const int WS_EX_TOPMOST = 0x8; //make it the topmost window
        //and we need these ones later on, too to achieve semi-transparency
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_LAYERED = 0x80000;
        private const int LWA_ALPHA = 0x2;
        private double opacity = 0.8; //between 0 and 1
        public ShaderControl()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            //here we create the window parameters
            //this will be called once when the window is created
            get
            {
                CreateParams p = base.CreateParams;
                p.ExStyle |= (WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
                return p;
            }
        }
        public new void Show()
        {
            //here we make the window a child of the desktop
            if (this.Handle == IntPtr.Zero)
            {
                base.CreateControl();
            }
            SetParent(base.Handle, IntPtr.Zero);
            ShowWindow(base.Handle, 1);
        }
        protected sealed override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                //every time the window gets shown we have to update the window attributes
                //the important thing here is the WS_EX_LAYERED attribute, this makes it possible to achieve semi-transparency
                int wl = GetWindowLong(this.Handle, GWL_EXSTYLE);
                wl = wl | WS_EX_LAYERED;
                SetWindowLong(this.Handle, GWL_EXSTYLE, wl);
                SetLayeredWindowAttributes(this.Handle, 0, (byte)(opacity * 255), LWA_ALPHA);
            }
        }
        public double Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                //when the opacity changes we have to renew the window attributes
                opacity = value > 0d ? Math.Min(1d, value) : Math.Max(0d, value);
                SetLayeredWindowAttributes(this.Handle, 0, (byte)(opacity * 255), LWA_ALPHA);
            }
        }
    }

    using System.Runtime.InteropServices;
    
    ..
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);
        struct IconHandler
        {
            internal const uint WmSeticon = 0x80u;
            internal const int IconSmall = 0x0;
            internal const int IconBig = 0x1;
        }
        public Main()
        {
            InitializeComponent();
            
			//Properties.Resources.Icon.Handle is just an .*ico file in your resources. Icons can have different sizes.
            SendMessage(Handle, IconHandler.WmSeticon, IconHandler.IconSmall, Properties.Resources.Icon.Handle);
            SendMessage(Handle, IconHandler.WmSeticon, IconHandler.IconBig, Properties.Resources.Icon.Handle);
		}

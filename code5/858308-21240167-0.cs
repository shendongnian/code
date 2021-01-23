        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SipGetInfo(
            ref SIPINFO sipInfo);
        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SipSetInfo(
            ref SIPINFO sipInfo);
        [StructLayout(LayoutKind.Sequential)]
        public struct SIPINFO
        {
            public uint cbSize;
            public uint fdwFlags;
            public RECT rcVisibleDesktop;
            public RECT rcSipRect;
            public uint dwImDataSize;
            public IntPtr pvImData;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        private void ShowInputPanel(Control control)
        {
            InputPanel.SIPINFO sipInfo;
            var x = 100;
            var y = control.PointToScreen(new Point(110, 150)).Y;            //control.Height
            this.inputPanel1.Enabled = true;
            sipInfo = new InputPanel.SIPINFO();
            sipInfo.cbSize = (uint)Marshal.SizeOf(sipInfo);
            if (InputPanel.SipGetInfo(ref sipInfo))
            {
                sipInfo.rcSipRect.left = x;
                sipInfo.rcSipRect.top = y;
                InputPanel.SipSetInfo(ref sipInfo);
            }
        }
        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            this.ShowInputPanel(this.textBox1);        
        }

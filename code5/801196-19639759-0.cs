        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int extraInfo);
        [DllImport("user32.dll")]
        static extern short MapVirtualKey(int wCode, int wMapType);
        private void button1_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                keybd_event((int)Keys.ShiftKey, (byte)MapVirtualKey((int)Keys.ShiftKey, 0), 2, 0); // Shift Up
            }
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) 
            {
                keybd_event((int)Keys.ControlKey, (byte)MapVirtualKey((int)Keys.ControlKey, 0), 2, 0); // Control Up
            }
            // ... now try sending your message ...
        }

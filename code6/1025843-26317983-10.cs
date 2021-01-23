    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public extern static bool ShutdownBlockReasonCreate(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string pwszReason);
        private bool blocked = false;
        protected override void WndProc(ref Message aMessage)
        {
            const int WM_QUERYENDSESSION = 0x0011;
            const int WM_ENDSESSION = 0x0016;
            if (blocked && (aMessage.Msg == WM_QUERYENDSESSION || aMessage.Msg == WM_ENDSESSION))
                return;
            base.WndProc(ref aMessage);
        }
               
        void Button1_Click(object sender, FormClosingEventArgs e)
        {
            if (ShutdownBlockReasonCreate(this.Handle, "DONT:"))
            {
                blocked = true;
                MessageBox.Show("Shutdown blocking succeeded");
            }
            else
                MessageBox.Show("Shutdown blocking failed");
        }
    }

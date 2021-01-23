    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class HighLight : Form
    {
        public HighLight()
        {
            Opacity = 0;
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
        }
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Hide();
        }
        private const int SW_SHOWNOACTIVATE = 4;
        private const int HWND_TOPMOST = -1;
        private const uint SWP_NOACTIVATE = 0x0010; 
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(int hWnd, int hWndInsertAfter,
             int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public void ShowInactiveTopmost()
        {
            ShowWindow(this.Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(this.Handle.ToInt32(), HWND_TOPMOST,
            this.Left, this.Top, this.Width, this.Height,
            SWP_NOACTIVATE);
            this.Opacity = 1;
        }
    }

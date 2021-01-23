    private void button1_Click(object sender, EventArgs e)
    {
        using (new SizeWinDialog(this)
        {
            PreferredSize = new Size(150, 150)//Change this size to whatever you want
        })
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
        }
    }
    class SizeWinDialog : IDisposable
    {
        private int mTries = 0;
        private Form mOwner;
    
        public SizeWinDialog(Form owner)
        {
            mOwner = owner;
            owner.BeginInvoke(new MethodInvoker(findDialog));
        }
    
        public Size PreferredSize { get; set; }
    
        private void findDialog()
        {
            // Enumerate windows to find the message box
            if (mTries < 0) return;
            EnumThreadWndProc callback = new EnumThreadWndProc(checkWindow);
            if (EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero))
            {
                if (++mTries < 10) mOwner.BeginInvoke(new MethodInvoker(findDialog));
            }
        }
        private bool checkWindow(IntPtr hWnd, IntPtr lp)
        {
            // Checks if <hWnd> is a dialog
            StringBuilder sb = new StringBuilder(260);
            GetClassName(hWnd, sb, sb.Capacity);
            if (sb.ToString() != "#32770") return true;
            // Got it
            RECT dlgRect;
            GetWindowRect(hWnd, out dlgRect);
            SetWindowPos(new HandleRef(this, hWnd), new HandleRef(), dlgRect.Left, dlgRect.Top, 100, 100, 20 | 2);
            return false;
        }
        public void Dispose()
        {
            mTries = -1;
        }
    
        // P/Invoke declarations
        private delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);
        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();
        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT rc);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy,
            int flags);
    
        private struct RECT { public int Left; public int Top; public int Right; public int Bottom; }
    }

    public partial class Form2 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPosFlags uFlags);
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private IntPtr mainHandle;
        private IntPtr processHandle;
        private Panel panel;
        public Form2()
        {
            InitializeComponent();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            AddPanel();
        }
        private void AddPanel()
        {
            panel = new Panel {Dock = DockStyle.Fill};
            mainHandle = panel.Handle;
            Controls.Add(panel);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Invoke((MethodInvoker) Close);
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var process = Process.Start("cmd.exe", "/k echo echo");
            if (process != null)
            {
                while (process.MainWindowHandle == IntPtr.Zero)
                {
                    // Add some sort of timeout here, infintite loops are bad!!!
                }
                processHandle = process.MainWindowHandle;
                // Get the size of the EXE window and apply it to this form.
                var size = GetSize(processHandle);
                Invoke((MethodInvoker) delegate { Size = new Size(size.Width, size.Height);});
                
                // Hook the parent of the EXE window to this form
                SetHandle(processHandle);
                // Make sure the windows is positions at location x = 0, y = 0 of this form
                SetWindowPos(processHandle, IntPtr.Zero, 0, 0, size.Width, size.Height, SetWindowPosFlags.SWP_ASYNCWINDOWPOS);
                // wait for the EXE to terminate
                process.WaitForExit();
                // Unhook the closed process window
                SetParent(processHandle, IntPtr.Zero);
            }
        }
        private void SetHandle(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
                SetParent(processHandle, mainHandle);
        }
        private static Size GetSize(IntPtr hWnd)
        {
            RECT pRect;
            var size = new Size();
            GetWindowRect(hWnd, out pRect);
            size.Width = pRect.Right - pRect.Left;
            size.Height = pRect.Bottom - pRect.Top;
            return size;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [Flags]
        private enum SetWindowPosFlags : uint
        {
            SWP_ASYNCWINDOWPOS = 0x4000,
            SWP_DEFERERASE = 0x2000,
            SWP_DRAWFRAME = 0x0020,
            SWP_FRAMECHANGED = 0x0020,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOACTIVATE = 0x0010,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOMOVE = 0x0002,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOREDRAW = 0x0008,
            SWP_NOREPOSITION = 0x0200,
            SWP_NOSENDCHANGING = 0x0400,
            SWP_NOSIZE = 0x0001,
            SWP_NOZORDER = 0x0004,
            SWP_SHOWWINDOW = 0x0040,
        }
    }

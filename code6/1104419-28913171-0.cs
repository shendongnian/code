    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    namespace SOF_ProcessFront
    {
    public partial class Form1 : Form
    {
        const UInt32 WS_MAXIMIZE = 365887488;
        const int GWL_STYLE = -16;
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr wHnd, int cmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        public Form1()
        {
            InitializeComponent();
            LoadOpenedWindows();
        }
        void bringProcessToFront(int pid)
        {
            Process proc = Process.GetProcessById(pid);
            int style = GetWindowLong(proc.MainWindowHandle, GWL_STYLE);
            ShowWindow(proc.MainWindowHandle,
                (style & WS_MAXIMIZE) == WS_MAXIMIZE ? 3 : 9 );
            SetForegroundWindow(Process.GetProcessById(pid).MainWindowHandle);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bringProcessToFront(0);
        }
        public void LoadOpenedWindows()
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                    listBox1.Items.Add(new ProcessAttributes()
                    {
                        ProcessName = process.MainWindowTitle,
                        ProcessID = process.Id
                    });
            listBox1.DisplayMember = "ProcessName";
            listBox1.DoubleClick += listBox1_DoubleClick;
        }
        void listBox1_DoubleClick(object sender, EventArgs e)
        {
            bringProcessToFront(((ProcessAttributes)listBox1.SelectedItem).ProcessID);
        }
        class ProcessAttributes
        {
            public string ProcessName { get; set; }
            public int ProcessID { get; set; }
        }
    }
    }

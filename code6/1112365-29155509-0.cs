    public partial class Form2 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, Int32 wParam, Int32 lParam);
        public Form2()
        {
            InitializeComponent();
            Process process = new Process();
            process.StartInfo.FileName = "Notepad.exe";
            process.Start();
            process.WaitForInputIdle();
            SetParent(process.MainWindowHandle, panel1.Handle);
            //This maximizes the process window.
            SendMessage(process.MainWindowHandle, 274, 61488, 0);
            return;
        }
    }

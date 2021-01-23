    using System.Runtime.InteropServices;
    using System.Diagnostics;
    ...
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        string targetTitle = "Notepad2";
        Process theProcess = null;
        public Form1()
        {
            InitializeComponent();
            // make the form clickthrough..
            TransparencyKey = Color.Fuchsia;
            BackColor = TransparencyKey;
            // find and keep a reference to the target process
            theProcess = findProcess(targetTitle);
            // our overlay should stay on top
            TopMost = true;
        }
        Process findProcess(string processTitle)
        {
            Process[] processList = Process.GetProcesses();
            return processList.FirstOrDefault(
                   pr => pr.MainWindowTitle.ToLower().Contains(targetTitle.ToLower()));
        }
        void setActive(Process theProcess)
        {
            if (theProcess == null)
            { Text = "Process " + targetTitle + " not found"; return; }
            Text += SetForegroundWindow(theProcess.MainWindowHandle) ? "OK" : " not OK";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // do your stuff..
            Console.WriteLine("Testing Button 1");
            // done: bring the target process back:
            setActive(theProcess);
        }
    }

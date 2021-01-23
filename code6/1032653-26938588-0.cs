    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Threading.Timer _timer;
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new TextBlock() { Text = "Close notepad.exe when you want..." };
            // - Launch process
            Process p = Process.Start("notepad.exe");
            int processId = p.Id;
            _timer = new System.Threading.Timer(new System.Threading.TimerCallback(o => CheckPID((int)o)), processId, 0, 1000);
        }
        /// <summary>
        /// Check if Process has exited
        /// </summary>
        /// <remarks>This code is NOT in UI Thread</remarks>
        /// <param name="processId">Process unique ID</param>
        private void CheckPID(int processId)
        {
            bool stillExists = false;
            //Process p = Process.GetProcessById(processId); // - Raises an ArgumentException if process has alredy exited
            Process p = Process.GetProcesses().FirstOrDefault(ps => ps.Id == processId);
            if (p != null)
            {
                if (!p.HasExited)
                    stillExists = true;
            }
            // - If process has exited, do remaining work and stop timer
            if (!stillExists)
            {
                _timer.Dispose();
                // - Ask UI thread to execute the final method
                Dispatcher.BeginInvoke(new Action(ExternalProcessEnd), null);
            }
        }
        /// <summary>
        /// The external process is terminated
        /// </summary>
        /// <remarks>Executed in UI Thread</remarks>
        private void ExternalProcessEnd()
        {
            MessageBox.Show("Process has ended");
        }
    }

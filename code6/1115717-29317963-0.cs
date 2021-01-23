    public partial class MainForm : UserControl
    {
        public ManualResetEvent SignalEvent = new ManualResetEvent(false);
        private ProgressForm2 _progressForm;
        public volatile bool CancelTask;
        public MainForm()
        {
            InitializeComponent();
            this.Name = "MainForm";
            var button = new Button();
            button.Text = "Run";
            //button.Click += button1_Click;
            button.Dock = DockStyle.Fill;
            this.Controls.Add(button);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CancelTask = false;
            ShowProgressFormInNewThread();
        }
        internal void ShowProgressFormInNewThread()
        {
            var thread = new Thread(new ParameterizedThreadStart(ShowProgressForm));
            thread.Start(Globals.ThisAddIn.Application.Hwnd);
            //The main thread will block here until the signal event is set in the ProgressForm_Load.
            //this will allow us to do the work load in the main thread (required by VSTO projects that access the Excel object model),
            SignalEvent.WaitOne();
            SignalEvent.Reset();
			ExecuteTask();
        }
        private void ExecuteTask()
        {
            for (int i = 1; i <= 100 && !CancelTask; i++)
            {
                ReportProgress(i);
                Thread.Sleep(100);
				// as soon as the Excel window becomes the owner of the progress dialog
				// then DoEvents() is required for the progress bar to update
				Application.DoEvents();
            }
        }
        private void ReportProgress(int percent)
        {
            if (CancelTask)
                return;
            _progressForm.BeginInvoke(new Action(() => _progressForm.UpdateProgress(percent)));
        }
        private void ShowProgressForm(Object o)
        {
            _progressForm = new ProgressForm2(this);
            _progressForm.StartPosition = FormStartPosition.CenterParent;
			SetWindowLong(_progressForm.Handle, -8, (int) o); // <-- set owner
            _progressForm.ShowDialog();
        }
		[DllImport("user32.dll")]
		static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }

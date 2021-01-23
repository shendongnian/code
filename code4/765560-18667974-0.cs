    public partial class Form1 : Form
    {
        private BackgroundWorker _objectA;
        public Form1()
        {
            InitializeComponent();
            _objectA = new BackgroundWorker();
            _objectA.DoWork += new DoWorkEventHandler(_objectA_DoWork);
            _objectA.ProgressChanged += new ProgressChangedEventHandler(_objectA_ProgressChanged);
            _objectA.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_objectA_RunWorkerCompleted);
            _objectA.WorkerReportsProgress = true;
            _objectA.WorkerSupportsCancellation = true;
            _objectA.RunWorkerAsync();
        }
        private int _count = 0;
        private void _objectA_DoWork(object sender, DoWorkEventArgs e)
        {
            _count = 0;
            while (_count < 20)
            {
                _count++;
                _objectA.ReportProgress(0);
                if (_objectA.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                Thread.Sleep(500);
            }
        }
        private int _red = 128;
        private int _green = 128;
        private int _blue = 128;
        private void _objectA_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _red += 15;
            if (_red > 255) _red = 128;
            _green -= 15;
            if (_green < 0) _green = 128;
            _blue += 15;
            if (_blue > 255) _blue = 128;
            this.BackColor = Color.FromArgb(_red, _green, _blue);
            this.Text = string.Format("Count = {0}", _count);
        }
        private void _objectA_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_objectA != null && _objectA.IsBusy)
            {
                _objectA.CancelAsync();
            }
        }
    }

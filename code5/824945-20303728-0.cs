    public partial class Form1 : Form
    {
        bool _isWorking = false;
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_isWorking)
            {
                // Cancel the worker
                backgroundWorker1.CancelAsync();
                button1.Enabled = false;
                return;
            }
            _isWorking = true;
            button1.Text = "Cancel";
            backgroundWorker1.RunWorkerAsync();
        }
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (var i = 0; i < 10; i++)
            {
                if (backgroundWorker1.CancellationPending) { return; }
                Thread.Sleep(1000);
            }
            e.Result = "SomeResult";
        }
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _isWorking = false;
            button1.Enabled = true;
            button1.Text = "Run";
            if (e.Cancelled) return;
            // Some type checking
            string theResult = e.Result as string;
            if (theResult == null) return; // Or throw an error or whatever u want
            MessageBox.Show(theResult);
        }
    }

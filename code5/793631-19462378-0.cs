    public partial class Form1 : Form
    {
        BackgroundWorker bw = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };  
        public Form1()
        {
            InitializeComponent();
            bw.DoWork += (bwSender, bwArg) =>
            {
                //MethodCall1(); - Does some database insertions..
                bw.ReportProgress(50);
                //MethodCall2(); - Does some database select...
                bw.ReportProgress(100);
            };
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += (bwSender, bwArg) =>
            {
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy)
            {
                return;
            }
             
            bw.RunWorkerAsync();
        }
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }

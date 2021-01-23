    public partial class Form1 : Form
    {
        BackgroundWorker bgw;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bgw = new BackgroundWorker();
            bgw.DoWork += YourCrazyLoopHere;
            bgw.ProgressChanged += UpdateProgressBar;
            bgw.RunWorkerCompleted += CrazyLoopDone;
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync();
        }
        private void CrazyLoopDone(object sender, RunWorkerCompletedEventArgs e)
        {
            //finishing up stuff, perhaps hide the bar or something?
            progressBar1.Visible = false;
        }
        private void UpdateProgressBar(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void YourCrazyLoopHere(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                /*lots of work loop here*/
                bgw.ReportProgress(1);//between 0 and 100
            }
        }
    }

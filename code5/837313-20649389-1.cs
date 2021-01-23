    public partial class Form1 : Form
    {
        Popup popupForm = new Popup();
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += backgroundWorkerDoWork;
            backgroundWorker.ProgressChanged += backgroundWorkerProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorkerRunWorkerCompleted;
        }
        void backgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                //What do you want to do if Cancelled?
            }
            else if (!(e.Error == null))
            {
                //What do you want to do if there is an error?
            }
            else
            {
                //What do you want to do when it is done?
            }
        }
        void backgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!popupForm.isOpen || popupForm == null)
            {
                popupForm = new Popup();
                popupForm.Show();
                popupForm.isOpen = true;
            }
            else
            {
                popupForm.Activate();
                popupForm.WindowState = FormWindowState.Normal;
            }
            popupForm.PopupListBox.Items.Add(e.ProgressPercentage.ToString() + "%");
        }
        void backgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 1; (i <= 10); i++)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress((i * 10));
                }
            }
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy != true)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.WorkerSupportsCancellation == true)
            {
                backgroundWorker.CancelAsync();
            }
        }
    }

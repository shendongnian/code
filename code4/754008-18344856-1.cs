    public partial class Form1 : Form
    {
        BackgroundWorker w = new BackgroundWorker();
    
        public Form1()
        {
            InitializeComponent();
            w.WorkerSupportsCancellation = true;
            w.DoWork += new DoWorkEventHandler(w_DoWork);
            w.RunWorkerAsync();
        }
    
        void w_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10000000000; i++)
            {
                if (w.CancellationPending)
                {
                    MessageBox.Show("Cancelled");
                    break;
                }
                //Do things...
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            w.CancelAsync();
        }
    }

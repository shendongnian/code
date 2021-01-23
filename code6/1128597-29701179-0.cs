    public partial class Form1 : Form1
    {
        public static string[] employeeName;
    
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(employeeName);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] employeeName = (string[])e.Argument;
            //Just for example sake
            for (int q = employeeName.GetLowerBound(0); q <= employeeName.GetUpperBound(0); q++)
            {
              MessageBox.Show(employeeName[q];
            }
        }
    }

    public partial class Form1 : Form
    {
        private BackgroundWorker bgw = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
        }
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (ServiceManagement.ServiceStatus("OracleServiceXE"))
                {
                    bgw.ReportProgress(-1, Color.Green);
                }
                else
                {
                    bgw.ReportProgress(-1, Color.Red);
                }
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }
        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ovalshape.BackColor = (Color)e.UserState;
        }
    }

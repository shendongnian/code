    public partial class MainForm : Form
    {
        engine connEngine = new engine();
        public MainForm()
        {
            InitializeComponent();
            connEngine.log = s => { msgLog(s); };
        }
        private void Start_Click(object sender, EventArgs e)
        {
            msgLog("Connection Start Clicked");
            if (connEngine.StartConnection(txtIPAddress.Text, 8002) == false)
            {
                msgLog("Connection Start Failed"); 
            }
            else
            {
                msgLog("Connection Start Success");
            }
        }
        void msgLog(string message)
        {
            txtMessageLog.AppendText(message + Environment.NewLine);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            msgLog("Form Load Success");
        }
    }
    class engine
    {
        internal Action<string> log;
        public bool StartConnection(string txtIPAddress, int p)
        {
            log("StartConnection started");
            //do something
            return true;
        }
    }

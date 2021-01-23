    public partial class fConn : Form
    {
        public SaveDelegate SaveCallback;
        public fConn()
        {
            InitializeComponent();
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            SaveCallback("set text what you need to send to main form here...");
        }
    }

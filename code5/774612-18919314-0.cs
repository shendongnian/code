    public partial class MazeForm : Form
    {
        public MazeForm()
        {
            InitializeComponent();
        }
    
        private bool okButton = false;
    
        public bool OKButtonClicked
        {
            get { return okButton; }
        }
    
        private void btnOK_Click(object sender, EventArgs e)
        {
            okButton = true;
            this.Close();
        }
    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            okButton = false;
            this.Close();
        }
    }

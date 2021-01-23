    public partial class FollowUp : Form
    {
        private string _So;
        
        public FollowUp(string so)
        {
            InitializeComponent();
            _So = so;
            [code]
        }
        
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (_So != "")
            {
                some code
            }
        }
    }

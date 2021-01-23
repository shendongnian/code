No Change here
    public partial class UserControl1 : UserControl
    {
        public event dlgBack Back;
        private UserControl1 _previous = null;
        public delegate void dlgBack(UserControl1 sender, UserControl1 previous);
        public UserControl1(UserControl1 previous)
        {
            InitializeComponent();
            this._previous = previous;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Back != null)
            {
                Back(this, _previous);
            }
        }
    }

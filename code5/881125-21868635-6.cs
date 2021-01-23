    public partial class DBTextBox : TextBox
    {
        private bool enabled;
        public new bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                base.Enabled = true;
                ReadOnly = !enabled;
            }
        }
        public DBTextBox()
        {
            InitializeComponent();
        }
    }

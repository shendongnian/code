    public partial class FrmProperty : Form
    {
        public string ApplicationString { get; set; }
        public FrmProperty()
        {
            InitializeComponent();
            this.Load += FrmProperty_Load;
        }
        private void FrmProperty_Load(object sender, EventArgs e)
        {
            MessageBox.Show(ApplicationString);
        }
    }

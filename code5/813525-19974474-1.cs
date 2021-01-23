    public partial class FrmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            new Class1().Visibility(this);
        }
        public void Go()
        {
            this.label1.Visible = false;
        }
    }

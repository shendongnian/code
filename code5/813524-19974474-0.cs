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
    public partial class Class1
    {
        public void Visibility(FrmMain form)
        {
           form.Go();            
        }
    }

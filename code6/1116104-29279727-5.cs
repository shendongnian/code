    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        Form1 form1 = new Form1();
        private void Splash_Load(object sender, EventArgs e)
        {
            form1.WindowState = FormWindowState.Minimized;
            form1.Hide();
        }
    }

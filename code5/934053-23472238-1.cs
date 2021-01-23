    public partial class MainForm : Form
    {
        ChildForm frm = new ChildForm();
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            frm.Show();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            frm.textBox1.Text = "Child from Parent";
            frm.button1.PerformClick();
        }
    }

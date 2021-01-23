    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.MdiParent = this;
            form2.tb = textBox1.Text;
            form2.Show();
        }
    }
    public partial class Form2 : Form
    {
        private string v;
        public Form2()
        {
            InitializeComponent();
        }
        public string tb
        {
            get { return textBox1.Text; }
            set { v = value; textBox1.Text = v; }
        }
    }

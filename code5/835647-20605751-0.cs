    public partial class Form1 : Form
    {
        public Form2 f2;
        public Form1()
        {
            InitializeComponent();
            
            f2 = new Form2();
            f2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f2.SetLabelText("testing");
        }
    }

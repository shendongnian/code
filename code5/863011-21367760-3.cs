    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "original text";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }
    }

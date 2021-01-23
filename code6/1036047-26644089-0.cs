    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetButtonEnableState();
        }
        private void SetButtonEnableState()
        {
            button1.Enabled = !(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text));
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            textBox3.Text = (a + b).ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnableState();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.SetButtonEnableState();
        }
    }

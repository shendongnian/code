    public partial class Form1 : Form
    {
        private int number = 411;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.textBox1.Text = number.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this.number);
            if (f2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.number = f2.Number;
                this.textBox1.Text = this.number.ToString();
            }
        }
    }

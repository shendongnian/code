    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            obj.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form2_FormClosing);
            obj.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Form2_FormClosed);
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Form2 closed.");
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Form2 closing.");
        }
    }

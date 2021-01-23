    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           button1.Text = Properties.Settings.Default.button1;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            button1.Text = "Saving...";
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveProperties();
        }
        private void SaveProperties()
        {
            Properties.Settings.Default.button1 = textBox1.Text;
            Properties.Settings.Default.Save();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = textBox1.Text;
        }
    }

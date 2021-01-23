    public partial class Form1 : Form
    {
        Form2 f2;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f2 = new Form2();
            f2.ShowDialog(this); // or f2.Show(this) if you want f2 to be non Modal
        }
        public void SerialPortValueUpdated()
        {
            MessageBox.Show("Test");
        }
    }

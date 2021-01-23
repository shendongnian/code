    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Owner).SerialPortValueUpdated();
        }
    }

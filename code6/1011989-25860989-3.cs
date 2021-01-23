    public partial class Form2 : Form
    {
        Form3 f3;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Owner).SerialPortValueUpdated();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            f3 = new Form3();
            f3.ShowDialog(this.Owner); 
        }
    }
    

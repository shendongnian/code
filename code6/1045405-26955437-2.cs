    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Alert AlertObj = new Alert();
            if (AlertObj.ShowDialog() == DialogResult.Yes)
                textBox1.Text = AlertObj.ResultText ;
            else
                textBox1.Text = "No";
    
        }
    }
    
    
     public partial class Alert : Form
    {
        public Alert()
        {
            InitializeComponent();
        }
    
        public string ResultText {get; set;}
        private void button1_Click(object sender, EventArgs e)
        {
            ResultTest = "Yes";
            DialogResult = DialogResult.Yes;    
        }
    }

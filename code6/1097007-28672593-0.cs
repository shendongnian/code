    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        // Will return string on textBox1 uppon calling
         private string ab(){
           return textBox1.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ab());
        }     
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ab()+" Hello");
        }
    }

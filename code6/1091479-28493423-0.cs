    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            DoMyWork();
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
        
        // Public method to desired work
        public void DoMyWork() (){
           textBox1.Text = "Hello World";
        }
    }

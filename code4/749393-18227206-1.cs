    namespace deneme_readimg
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {  
                DirectoryInfo dir = new DirectoryInfo("C:\\DENEME");
    
                // Clear the contents first
                textBox1.Clear();
                foreach (FileInfo file in dir.GetFiles())
                {
                    // Append each item
                    textBox1.AppendText(file.Name); 
                }
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
    
            }
        }
    }

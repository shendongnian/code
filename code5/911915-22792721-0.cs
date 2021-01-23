    namespace canceldemo
    {
        public partial class Form1 : Form
        {
            int i = 1;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (i == 1)
                {
                    MessageBox.Show("Hello");
                    e.Cancel = true;
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                label1.Text = (i+10).ToString();
            }
        }
    }

    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("1 clicked");
                button2.PerformClick();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                MessageBox.Show("2 clicked");
            }
        }

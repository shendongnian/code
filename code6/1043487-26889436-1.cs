    public partial class Form1 : Form
    {
            public Form1()
            {
                InitializeComponent();
                textBox1.Text = "aaa";
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                textBox1.Font = new Font(textBox1.Font, (textBox1.Font.Style == FontStyle.Bold) ? FontStyle.Regular : FontStyle.Bold);
           }
    }

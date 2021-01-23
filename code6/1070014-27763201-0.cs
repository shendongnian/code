    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                EventHandler TextChanged_EventHandler = new EventHandler(textBox1_TextChanged);
                textBox1.TextChanged -= TextChanged_EventHandler;
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                MessageBox.Show("BUG");
            }
        }

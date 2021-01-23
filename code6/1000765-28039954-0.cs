    public partial class Form1 : Form
    {
        string origValue = string.Empty;
        public Form1()
        {
            InitializeComponent();
            origValue = textBox1.Text;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {            
            if (textBox1.Text.Contains("12/10/2015"))
            {
                origValue = textBox1.Text;
            }
            else
            {
                textBox1.Text = origValue;
            }
        }
    }

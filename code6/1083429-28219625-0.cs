    public partial class Form1 : Form
    {
        public const char Prefix = '<';
        public const char Suffix = '>';
        private readonly List<string> _tags = new List<string> {"email"};
        public Form1() { InitializeComponent(); }
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            int startOfVar = 0;
            int endOfVar = -1;
            for (int i = richTextBox1.SelectionStart - 1; i >= 0; i--)
            {
                if (richTextBox1.Text[i] == Suffix)
                    return;
                if (richTextBox1.Text[i] == Prefix)
                {
                    startOfVar = i + 1;
                    break;
                }
            }
            for (int i = startOfVar; i < richTextBox1.TextLength; i++)
            {
                if (richTextBox1.Text[i] == Suffix)
                {
                    endOfVar = i;
                    break;
                }
            }
            if (startOfVar < endOfVar)
            {
                var varString = richTextBox1.Text.Substring(startOfVar, endOfVar - startOfVar);
                if (_tags.Contains(varString))
                {
                    richTextBox1.Select(startOfVar - 1, endOfVar - startOfVar + 2);
                }
            }
        }    
        
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(Prefix + _tags[0] + Suffix);
        }
    }

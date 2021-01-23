    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool _textChanged;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            _textChanged = true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_textChanged)
            {
                if (MessageBox.Show("save changes?", 
                                   "some caption",
                                   MessageBoxButtons.YesNoCancel) == 
                   System.Windows.Forms.DialogResult.Yes) 
                {
                    //save changes...
                } 
            }
        }
    }

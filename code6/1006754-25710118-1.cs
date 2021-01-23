    public partial class Form1 : Form
    { 
        private bool _textChanged;
        public Form1()
        {
            InitializeComponent();
           // load data to richtextbox, then ....
            _textChanged = false;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            _textChanged = true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_textChanged)
            {
                DialogResult rslt = MessageBox.Show("save changes?", "some caption",
                                   MessageBoxButtons.YesNoCancel);
                if (rslt == DialogResult.Yes)
                {
                    // save changes and exit
                }
                else if (rslt == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    // cancel close, return to form
                }
                // else do not save and continue closing form
            }
        }
    }

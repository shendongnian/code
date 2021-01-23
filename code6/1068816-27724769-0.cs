    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("asd");
                return true; // optionally suppress further processing of the enter key by other controls on the form
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

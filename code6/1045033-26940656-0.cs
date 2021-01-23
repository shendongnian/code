    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                MessageBox.Show("Enter");
                return true; // optionally prevent further action(s) on Enter; such as Button clicks
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

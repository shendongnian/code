    public partial class Form2 : Form
    {
        int passedValue = 0;
        public Form2(int secValue)
        {
            InitializeComponent();
            passedValue = secValue;
        }
    
        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    
        private void btnShow_Click(object sender, EventArgs e)
        {
               MessageBox.Show(string.Format(passedValue.ToString(), "My Application", MessageBoxButtons.OK));
        }
    }

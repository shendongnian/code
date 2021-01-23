    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double balance;
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(txtDeposit.Text);
            balance += value;
        }
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(txtWithdraw.Text);
            balance -= value;
        }
    }

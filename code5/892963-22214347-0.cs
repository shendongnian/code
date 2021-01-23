    public partial class Form1 : Form
    {
        public int Year {get; set;}
        public decimal Balance {get; set;}
        public decimal Remaining {get; set;}
        public decimal YearlyGoal {get; set;}
        public decimal YearlyInvest {get; set;}
        public decimal InterestRate {get; set;}
        public Form1()
        {
            InitializeComponent();
            this.Year = 0;
            this.Balance = 0;
            this.Remaining = 0;
            this.YearlyGoal = 100000;
            this.YearlyInvest = 2000;
            this.InterestRate = 0.06;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBoxYear.DataBindings.Add("Text", this, "Year");
            this.textBoxBalance.DataBindings.Add("Text", this, "Balance", true, DataSourceUpdateMode.OnValidation, null, "c");
            this.textBoxRemaining.DataBindings.Add("Text", this, "Remaining", true, DataSourceUpdateMode.OnValidation, null, "c");
            this.textBoxYearlyGoal.DataBindings.Add("Text", this, "YearlyGoal", true, DataSourceUpdateMode.OnValidation, null, "c");
            this.textBoxYearlyInvest.DataBindings.Add("Text", this, "YearlyInvest", true, DataSourceUpdateMode.OnValidation, null, "c");
            this.textBoxInterestRate.DataBindings.Add("Text", this, "InterestRate");
        }
        private void buttonNextYear_Click(object sender, EventArgs e)
        {
            this.CurrentYear++;
            this.CurrentBalance += this.YearlyInvest;
            this.CurrentBalance += this,CurrentBalance * this.InterestRate;
            this.CurrentRemaining = this.YearlyGoal - this.CurrentBalance;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

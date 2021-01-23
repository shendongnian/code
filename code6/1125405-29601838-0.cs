    public partial class Form1 : Form
    {
        public DateTime bDate;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lblSeconds.Text = GetAge(Convert.ToDateTime(dtpInput.Text));
        }
        public string GetAge(DateTime bDate)
        {
            DateTime birthDate = bDate;
            TimeSpan Calculator = DateTime.Now - birthDate;
            int x = (int)Calculator.TotalSeconds;
            return x.ToString();
        }
    }

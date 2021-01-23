    public partial class Form1 : Form
    {
        string[] LinesWithDetails;
        string[] LinesWithOutDetails;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LinesWithDetails = richTextBox1.Lines;
            LinesWithOutDetails = richTextBox1.Lines.Where(l => l.Contains("Deposit")).ToArray();
            HideDetails();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                ShowDetails();
            else
                HideDetails();
        }
        private void ShowDetails()
        {
            richTextBox1.Lines = LinesWithDetails;
        }
        private void HideDetails()
        {
            richTextBox1.Lines = LinesWithOutDetails;
        }
        
    }

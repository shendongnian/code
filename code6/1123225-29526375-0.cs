    public partial class Spam_Scanner : Form
    {
        Tester scan;
        public Spam_Scanner()
        {
            InitializeComponent();
            scan = new Tester();
        }
        private void testButton_Click(object sender, EventArgs e)
        {            
            scan.tester(Convert.ToString(emailBox.Text));
            this.SpamRatingBox.Text = string.Format("{0:N1}%", Tester.countSpam / Tester.wordCount * 100);
            this.WordsBox.Text = Tester.posSpam;
            this.OutputPanal.Visible = true;
            this.pictureBox1.Visible = false;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            scan.addSpam(Convert.ToString(addFlagBox.Text));
            this.addFlagBox.Text = "";
        }
    }

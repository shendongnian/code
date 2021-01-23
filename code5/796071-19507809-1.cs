    public partial class SearchReplace : Form
    {
        Form1 form1 = new Form1();
        public SearchReplace()
        {
            InitializeComponent();
            form1.FormClosed += new FormClosedEventHandler(form1_FormClosed); // When Form1 Close
        }
        void form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close(); // When form1 is closed then close also SearchReplace form
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form1.searchT = textBox1.Text; // assign textbox1 to searchT
            form1.Show();
            this.Hide(); // Make SearchReplace form invisible but still in memory
        }
    }

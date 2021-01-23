    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void searchText(string searchT) // search function
        {
            if (searchT != null)
            {
                if (textBox1.TextLength > 0)
                {
                    if (textBox1.Text.Contains(searchT))
                    {
                        textBox1.Focus(); // put focus to the Textbox so we can see our selection
                        textBox1.SelectionStart = textBox1.Text.IndexOf(searchT);
                        textBox1.SelectionLength = searchT.Length;
                       
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SearchReplace sr = new SearchReplace(); // Creating your SearchReplace Form
            sr.Show(this);  // Pass the creating form in as the Owner
        }
    }

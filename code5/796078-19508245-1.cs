    public partial class SearchReplace : Form
    {
        public SearchReplace()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.Owner).searchText(textBox1.Text); //Cast the Owner to Form1 and access the Function 
                                                           //passing in your search Parameter
            this.Close();
        }
    }

    public class childForm : Form
    {
        public List<string> Items { get; set; }
     
        private void childForm_Load(object sender, EventArgs e)
        {
             lstMyListBox.DataSource  = Items;
        }
    }

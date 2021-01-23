    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
           
            customListView1.UpdateListViewCounts+=customListView1_UpdateListViewCounts;
        }
        private void customListView1_UpdateListViewCounts(object sender, CustomEventArgs e)
        {
            //You can check for the originating Listview if 
            //you have multiple ones and want to implement
            //Multiple Labels
            label1.Text = e.Count.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            customListView1.UpdateList("Hello");
        }
        
    }

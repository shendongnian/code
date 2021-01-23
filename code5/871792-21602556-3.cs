    public partial class _MyMaster : System.Web.UI.MasterPage
    {
        public int page_id { set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           // My Master page stuff
           if(page_id > 0) {}; // DO stuff with page ID
        }

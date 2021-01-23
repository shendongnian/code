    public partial class BaseMaster : System.Web.UI.MasterPage
    {
        public Node CurrentNode { get; set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentNode = Node.GetCurrent();
        }
    }

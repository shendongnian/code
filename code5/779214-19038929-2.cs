    public partial class GridWorker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var entityId = Request.QueryString["entityId"];
            var colName = Request.QueryString["colName"];
            var colValue = Request.QueryString["colValue"];
            
            //TODO: do some work
        }
    }

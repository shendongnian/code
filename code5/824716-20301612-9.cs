    public partial class SearchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            results.InnerHtml = Session["Results"].ToString();
        }
    }

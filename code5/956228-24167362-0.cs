    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
    }

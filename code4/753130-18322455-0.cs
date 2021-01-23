    public partial class MyPage : System.Web.UI.Page
    {
        protected bool showField = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            showField = Authentication.IsAuthorized(User.Identity.Name);
        }
    }

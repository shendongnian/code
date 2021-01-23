    public class MemberPageBase : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                this.RedirectToLogin();
            }
        }
        protected void RedirectToLogin()
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    public class SecureBase : System.Web.UI.Page
    {
        protected override OnLoad(Event Args etc...)
        {
            if (!CurrentUser.IsLoggedIn)
            {
                Response.Redirect("~/uh-uh-uh--You-didnt-say-the-magic-word.aspx");
            }
        }
    }

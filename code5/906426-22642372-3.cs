    public class BasePage : System.Web.UI.Page
    {
     protected override void OnInit(EventArgs e)
     {
        base.OnInit(e);
    
       if (Request.Cookies["Session"] != null && !CustomIsLoggedInCheckMethod)
       {
         String unprotected = Helper.Unprotect(Request.Cookies["Session"].Value, "sessionID");
         Guid sessionID = Guid.Parse(unprotected);
        // Calls to buisiness layer to get the user, set sessions values et cetera
       }
     }
    }

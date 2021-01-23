    using System.Web;
    public class AuthenticationUtilities
    {
        public static void CheckLogin()
        {
            if (Session["UserName"] == "" || Session["UserName"] == null)
            {
                Response.Redirect("Account/Login.aspx");
            }
        }
    }

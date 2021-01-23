    using System.Web;
    public class AuthenticationUtilities
    {
        public static void CheckLogin()
        {
            if (String.IsNullOrEmpty(Session["UserName"])) //switched to use String function to check for null or empty
            {
                Response.Redirect("Account/Login.aspx");
            }
        }
    }

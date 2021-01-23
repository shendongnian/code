    public class SessionHelper
    {
        public static void CheckLogin()
        {
            if ((Session["UserName"] == "") || (Session["UserName"] == null))
            {
            Response.Redirect("Account/Login.aspx");
            }
        }
    }

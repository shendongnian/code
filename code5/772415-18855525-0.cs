    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
    
    public class BasePage : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            int permission = Convert.ToInt32(Session["userpermission"] ?? "0");
            if (permission == 1 || permission == 2)
            {
                // User is authorized, so allow access.
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }

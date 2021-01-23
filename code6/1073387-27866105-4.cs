    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["myVariable"] != null)
                {
                    TextBox1.Text = Session["myVariable"].ToString();
                }
            }
        }
    }
     public partial class WebFormMP_TestPublicVariable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["myVariable"] = "Test";
            }
        }
    }

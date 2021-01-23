    namespace WebApplication2
    {
       public partial class _Default : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (ViewState["value"] != null)
                {
                    TextBox1.Text = Session["value"].ToString();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["value"] = TextBox1.Text;
            Response.Redirect("default.aspx");
        }
    }
}

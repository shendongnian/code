    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1_Click(sender, e);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("Calling event from an event...");
        }
    }

    public partial class result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
             firstlbl.Text = Request["fp"];
             secondlbl.Text = Request["sp"];
        }
    }

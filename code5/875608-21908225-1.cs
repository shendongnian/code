    namespace WebApplication3
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                this.Label1.Text = "change Test 1";
            }
    
            protected void LinkButton1_Click(object sender, EventArgs e)
            {
                this.Label1.Text = "change Test 2";
            }
        }
    }

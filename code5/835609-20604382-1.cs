    namespace WebApplication1
    {
        public partial class dropdown : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (ddlState.SelectedValue == "State A")
                {
                    pnlA.Visible=true;
                    pnlB.Visible = false;
                    pnlC.Visible = false;
                }
                else if (ddlState.SelectedValue == "State B")
                {
                    pnlA.Visible = false;
                    pnlB.Visible = true;
                    pnlC.Visible = false;
                }
                else
                {
                    pnlA.Visible = false;
                    pnlB.Visible = false;
                    pnlC.Visible = true;
                }
            }
        }
    }

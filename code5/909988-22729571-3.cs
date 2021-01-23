    public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void btnLink_Click(object sender, EventArgs e)
            {
                var uc = (UserControl)Page.LoadControl("~/WebUserControl1.ascx");
                pnl.Controls.Add(uc);            
            }
        }

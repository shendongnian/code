    public partial class Default : System.Web.UI.Page
        {
            UserControl uc; 
            protected void Page_Load(object sender, EventArgs e)
            {
               if(IsPostBack) // This condition is not needed but we know that click is always postback
                uc = (UserControl)Page.LoadControl("~/WebUserControl1.ascx");
            }
    
            protected void btnLink_Click(object sender, EventArgs e)
            {
                
                pnl.Controls.Add(uc);            
            }
        }

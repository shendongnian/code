    public partial class AwsomeUserControl : System.Web.UI.UserControl
    {
        public string OnClientClick { get; set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(OnClientClick))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "script", 
                OnClientClick, true);
            }
        }
    }

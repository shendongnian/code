    public partial class listSelector: System.Web.UI.UserControl
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (System.Web.HttpContext.Current.Session["searchProperty"] != null)
                {
                    string lastIndex = System.Web.HttpContext.Current.Session["searchProperty"].ToString();
                    this.SelectedValue = lastIndex;
                }
    
            }
        }
    
        private string SelectedValue
        {
            get; set;
        }
    }//end of class

    enter code here
        public partial class listSelector: System.Web.UI.UserControl
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (System.Web.HttpContext.Current.Session["searchProperty"] != null)
                {
                    string lastIndex = System.Web.HttpContext.Current.Session["searchProperty"].ToString();
                    listSelector.SelectedValue = lastIndex;
                }
    
            }
        }
    
        public string SelectedValue
        {
            get 
            {
                return listSelector.SelectedValue;
            }
            set 
            {
                listSelector.SelectedValue = value; 
            }
        }
    }//end of class

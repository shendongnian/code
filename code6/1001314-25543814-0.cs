    namespace WebApplication1
    {
        public partial class Team : System.Web.UI.Page
        {
            private readonly CommonFunctions _cf;
    
            public string CurrentUser;
    
            public Team() 
            {
                _cf = new CommonFunctions();
                CurrentUser = _cf.CurrentUser();
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(CurrentUser))
                {
                    // Do stuff here
                }
                else
                {
                    // Do other stuff here
                }
            }
        }
    }

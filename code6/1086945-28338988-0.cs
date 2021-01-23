    public partial class _Default : BasePage
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
        }
    
        public class BasePage : Page
        {
            public string UserName { get; set; }
    
    
            public BasePage()
            {
                if (!SetSession())
                {
                    
                }
    
            }
    
            private bool SetSession()
            {
                if (HttpContext.Current.Request != null && HttpContext.Current.Request.QueryString["myvalue"] != null)
                {
    
                    
                }
    
                return false;
            }
        }

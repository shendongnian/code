    public class MyBasePage : System.Web.UI.Page
    {
        protected User ActiveUser {get;set;};
    
        public MyBasePage()
        {
              ActiveUser = new User();
        }
    }

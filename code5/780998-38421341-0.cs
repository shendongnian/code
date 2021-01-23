    using System;
    using System.Web;
    public class MyBasePage : System.Web.UI.Page
    {
       protected User ActiveUser;
       public MyBasePage()
       {
           ActiveUser = new User();
       }
    }

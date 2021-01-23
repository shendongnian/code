    using System;
    using System.Web.UI.WebControls;
    
    namespace WebApplication2
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            private bool SiteSpecificAuthenticationMethod(string UserName, string Password)
            {
                // Insert code that implements a site-specific custom 
                // authentication method here.
                //
                // This example implementation always returns false.
                return false;
            }
    
            protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
            {
                bool Authenticated = false;
                Authenticated = SiteSpecificAuthenticationMethod(Login1.UserName, Login1.Password);
    
                e.Authenticated = Authenticated;
            }
        }
    }

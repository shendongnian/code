    public class PageBase: Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
    
            var secureAttr = Attribute.GetCustomAttribute(this.GetType(), typeof (SecureAttribute));
            if (secureAttr != null)
            {
                bool UserLoggedIn = false; // get actual state from DB or Session
    
                if (!UserLoggedIn)
                {
                    Response.Redirect("/login");
                }
            }
        }
    }

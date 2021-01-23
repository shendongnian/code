    protected void Page_Load(object sender, EventArgs e)
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                Response.Cache.SetNoStore();
                Session.Abandon();
                Session.Clear();
                System.Web.Security.FormsAuthentication.SignOut();    
                // DO NOT REDIRECT TO LOGIN PAGE FROM HERE
                // REDIRECT TO LOGIN PAGE FROM JAVASCRIPT
         
            }

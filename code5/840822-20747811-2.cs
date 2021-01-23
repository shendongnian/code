    public class CustomAuthenticationModule : IHttpModule 
          { 
               
                public void Init(HttpApplication httpApp) 
                { 
                      httpApp.AuthorizeRequest += new EventHandler(this.AuthorizaRequest); 
                      httpApp.AuthenticateRequest += new EventHandler(this.AuthenticateRequest); 
                } 
                public void Dispose() 
                {} 
                
                private void AuthorizaRequest( object sender, EventArgs e) 
                {     
                      if (HttpContext.Current.User != null) 
                      { 
                             if (HttpContext.Current.User.Identity.IsAuthenticated) 
                            { 
                                  if (HttpContext.Current.User is MyAppPrincipal) 
                                  { 
                                        
                                  MyAppPrincipal principal = (MyAppPrincipal) HttpContext.Current.User; 
                                  if (!principal.IsPageEnabled(HttpContext.Current.Request.Path) ) 
                                              HttpContext.Current.Server.Transfer( "unauthorized.aspx"); 
                                  } 
                            } 
                      } 
                } 
               
                private void AuthenticateRequest(object sender, EventArgs e) 
                { 
                      if (HttpContext.Current.User != null) 
                      { 
                            
                            if (HttpContext.Current.User.Identity.IsAuthenticated) 
                            { 
                                  if (HttpContext.Current.User.Identity is FormsIdentity) 
                                  { 
                                        var id = HttpContext.Current.User.Identity; 
                                        FormsAuthenticationTicket ticket = id.Ticket; 
                                        string cookieName = System.Web.Security.FormsAuthentication.FormsCookieName; 
                                        string userData = 
                                              System.Web.HttpContext.Current.Request.Cookies[cookieName].Value; 
     
                                        ticket  = FormsAuthentication.Decrypt(userData); 
     
                                        string department=""; 
                                        if( userData.Length > 0 ) 
                                              department= ticket.UserData; 
                                        HttpContext.Current.User = new 
                                        MyAppPrincipal(_identity, department);                          
                                  } 
                            } 
                      } 
                }//AuthenticateRequest 
          } //class 
    }

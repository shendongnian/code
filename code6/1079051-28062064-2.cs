    namespace InstagramLogin.Code
    {
        public class SessionInstaAuthUser
        {
     
                public bool isInSession()
                {
                    return HttpContext.Current.Session["AuthUserApiToken"] != null;
                }
           
                public AuthUserApiToken get()
                {
                    if (isInSession())
                    {
                        return HttpContext.Current.Session["AuthUserApiToken"] as AuthUserApiToken;
                    }
                    return null;
                }
    
                public void set(AuthUserApiToken value)
                {
                    HttpContext.Current.Session["AuthUserApiToken"] = value;
                }
    
                public void clear()
                {
                    if (isInSession())
                    {
                        HttpContext.Current.Session["AuthUserApiToken"] = null;
                    }
                }
    
        }
    }

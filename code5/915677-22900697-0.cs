    protected void Application_PreRequestHandlerExecute(object sender, EventArgs e) 
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
             url = url.ToUpper();
             if (System.Web.HttpContext.Current.Session == null && url.Contains("CONFIDENTIAL"))
    
            {                
                    Response.Redirect("Login.aspx");                                
            }
    
            if (System.Web.HttpContext.Current.Session != null && url.Contains("CONFIDENTIAL"))
            {                    
                if (Session["THISUSER"].ToString() != "OK")
                {
                    Response.Redirect("Login.aspx");
                }                                
            }
        }

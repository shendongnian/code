    protected void Application_BeginRequest(object sender, EventArgs e)
    {       
        string session_param_name = "SOME_SESSION_ID";        
        if (HttpContext.Current.Request.Form[session_param_name] == null)
        {
             //Count
        }
        else if (HttpContext.Current.Request.QueryString[session_param_name] == null)
        {
            //Also count
         }
    }

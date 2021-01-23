     protected void Session_OnStart()
        { 
           //Whatever is defaulted here
           System.Web.HttpContext.Current.Session["blah"] = "Your User Name"
        }

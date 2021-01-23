    protected void Application_AcquireRequestState(object sender, EventArgs e)
    {
         if (HttpContext.Current.Handler is IRequiresSessionState)
         {
             var usrobj = HttpContext.Current.Session["User"];
             if(usrobj == null)
             {
                 Response.Redirect("~/Login/Index");
             }
         }
    }

    override protected void OnInit(EventArgs e)
      {
           base.OnInit(e);   
    if (Context.Session != null)
       {
    if (Session.IsNewSession)
        {
          
         string CookieHeader = Request.Headers["Cookie"];
         if((CookieHeader!=null) && (CookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
         {
          // redirect to any page you need to
          Response.Redirect("sessionTimeout.aspx");
         } 
       }
     }
    }

    override protected void OnInit(EventArgs e)
      {
           base.OnInit(e);
    if (Session.IsNewSession)
        {
          
         string CookieHeader = Request.Headers["Cookie"];
         if((CookieHeader!=null) && (CookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
         {
          Response.Redirect("sessionTimeout.aspx");
         } 
       }
    }

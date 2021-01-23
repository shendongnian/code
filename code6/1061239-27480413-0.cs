    void Application_EndRequest(Object sender, EventArgs e)
    {
       if (Response.Cookies.Count > 0)
       {
           foreach (string s in Response.Cookies.AllKeys)
           {
               if (s == "ASP.NET_SessionId")
               {
                   Response.Cookies["ASP.NET_SessionId"].HttpOnly = false;
               }
           }
       }    
    }

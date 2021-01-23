          // This is a workaround for the fact that we are not using MVC and its attributes
          // This is the situation where a user is logged in - but not authorized for this page
          void Application_EndRequest (object sender, System.EventArgs e)
          {
             if (((Response.StatusCode == 302) && (Request.IsAuthenticated == true)))
             {
                try
                {
                   string sLoc = Response.Headers ["Location"];
                   if (sLoc.Contains ("Login"))
                   {
                      Response.ClearContent ();
                      Response.Redirect ("~/AccessDenied.aspx");
                   }
                }
                catch
                {
                }
             }
          }

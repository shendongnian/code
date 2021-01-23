    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        try
        {
            if (IsAutomation() && Request.Headers["Authorization"] != null)
            {
                // Your NTML handling code here; below is what I use for Basic auth
                string[] parts = Request.Headers["Authorization"].Split(' ');
                string credentials = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(parts[1]));
                string[] auth = credentials.Split(':');
                if (Membership.ValidateUser(auth[0], auth[1]))
                {
                    Context.User = Membership.GetUser(auth[0]);
                }
                else
                {
                    Response.Clear();
    
                    Response.StatusCode = 401;
                    Response.StatusDescription = "Access Denied";
                    Response.RedirectLocation = null;
                    Response.AddHeader("WWW-Authenticate", "Basic realm={my realm}");
                    Response.ContentType = "text/html";
                    Response.Write(@"
    <html>
    <head>
    <title>401 Access Denied</title>
    </head>
    <body>
    <h1>Access Denied</h1>
    <p>The credentials supplied are invalid.</p>
    </body>
    </html>");
                }
            }
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

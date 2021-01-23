     void Application_BeginRequest(Object sender, EventArgs e)
            {
                string path = Request.Path.ToLower();
    
                if (urls.Any(url=> url.Page_Url.Equals(path)))
                {
                    string handler = urls.First(url => url.Page_Url.Equals(path)).Page_Handler;
                    Context.RewritePath(@"~/" + handler);
                }
            }

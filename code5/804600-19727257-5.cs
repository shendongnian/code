        // fires anytime default.aspx is loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            // check if is ajax call and not normal page load in the browser
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                 Response.Clear();  //empty everithing so we don't send mixed content
                 // no cache on ajax, IE caches ajas if this is missing
                 Response.Cache.SetExpires(DateTime.Today.AddMilliseconds(1.0));
                 Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
                 // here we are checking what we want to do, what client side asked
                 if(!string.IsNullOrWhiteSpace(Request["ServerSideMethod"])) // this will be "1"
                 {
                      doAll(); // do your work
                 }
                 Response.End();
            }
        }
        private void doAll() 
        {
                // do work, then send some json, as this is what you expect         
                // JavaScriptSerializer is located in System.Web.Script.Serialization
                Response.Write(new JavaScriptSerializer().Serialize(new { ok = 1, error = 0 }));
        }

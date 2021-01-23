        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.Today.AddMilliseconds(1.0));
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                 Response.Clear();
                 if(!string.IsNullOrWhiteSpace(Request["ServerSideMethod"]))
                 {
                      doAll();
                 }
                 Response.End();
            }
        }
        private void doAll() 
        {
            //Do something
            Response.Write(JsonConvert.SerializeObject(new { ok = 1 })); // some json, as this is what you expect
        }

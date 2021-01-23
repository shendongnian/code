        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.Today.AddMilliseconds(1.0));
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                 if(!string.IsNullOrWhiteSpace(Request["ServerSideMethod"]))
                      doAll();
            }
        }
         public void doAll() 
        {
           //Do something
        }

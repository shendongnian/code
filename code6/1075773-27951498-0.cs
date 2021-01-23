        public void Init(HttpApplication context)
        {
            var sessionModule = context.Modules["Session"] as SessionStateModule;
            if (sessionModule != null)
            {
                sessionModule.Start += this.Session_Start;
            }
        }
        private void Session_Start(object sender, EventArgs e)
        {
            // Do whatever you want to do here.
        }

        public void StartBackgroundRequest()
        {
            var thread = new Thread(StartMethod);
            thread.Start(HttpContext.Current);
        }
        private void StartMethod(object state)
        {
            HttpContext.Current = (HttpContext)state;
 	        //bunch of stuff
            var request = NewRequest(className); // exception gets throw here
        }

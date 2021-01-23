        public async Task<ActionResult> Index()
        {
            System.Web.HttpContext.Current.Items["test"] = "test";
            var result = await SomethingAsync();
            
            return View();
        }
        private async Task<object> SomethingAsync()
        {
            await Task.Delay(1000).ConfigureAwait(false);
            // this will throw a nullpointer if ConfigureAwait is set to false
            return System.Web.HttpContext.Current.Items["test"];
        }

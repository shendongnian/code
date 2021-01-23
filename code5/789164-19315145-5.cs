    [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            foreach (var key in formCollection.AllKeys)
            {
                var value = formCollection[key];
            }
    
            foreach (var key in formCollection.Keys)
            {
                var value = formCollection[key.ToString()];
            }
    }

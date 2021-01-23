    [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
           
    
            for(int i=0;i<formCollection.AllKeys.Length;i++)
            {
                var value = formCollection["value"+i];
                var name=formCollection["name"+i];
            }
        }

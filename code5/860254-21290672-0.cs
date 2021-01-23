        [HttpPost]
        public ActionResult Index(MyModel model)
        {
             List<string> names = getNames();
        
            model.names = names;
            return View(model); 
        }

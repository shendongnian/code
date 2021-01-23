        [HttpPost]
        public ActionResult Index(MyModel model)
        {
             List<string> names = getNames();
        
            model.nameList = names;
            return View(model); 
        }

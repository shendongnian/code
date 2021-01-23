        [HttpGet]
        public ActionResult Index(List<Model> ItemsModelList)
        {
            ItemsModelList = new List<Model>()
            {                
                //example two values
                //checkbox 1
                new Model{ CheckBoxValue = true},
                //checkbox 2
                new Model{ CheckBoxValue = false}
            };
            return View(new ModelLists
            {
                List = ItemsModelList
            });
        }
        [HttpPost]
        public ActionResult Index(ModelLists ModelLists)
        {
            //Use a break point here to watch values
            //Code... (save for example)
            return RedirectToAction("Index", "Home");
        }

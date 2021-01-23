        [HttpGet]
        public ActionResult Index()
        {
            ExampleViewModel model = new ExampleViewModel();
            model.Add("rating1",new[] { "Yes" ,"No", "Maybe"});
            model.Add("rating2", new[] { "Yes", "No", "Maybe" });
            model.Add("rating3", new[] { "Yes", "No", "Maybe" });
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ExampleViewModel model)
        {
            //model.Answers is the dictionary of the values submitted 
            string s = model.Answers.Count.ToString();
            return View();
        }

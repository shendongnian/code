        public ActionResult Index()
        {
            var myViewModel = new MyViewModel(); // set up view model with data
            return View(myViewModel);
        }
 

        [HttpGet]
        public ActionResult Index()
        {           
            return View(new ProductViewModel()); // this model contains products you want to display
        }
        [HttpPost]
        public ActionResult Index(ProductViewModel model)
        {
            return View();
        } 

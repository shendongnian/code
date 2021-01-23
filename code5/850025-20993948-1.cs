        [HttpPost]
         
        public ActionResult Index(string username)
        {
             ViewBag.user=username; 
             return View();
        }

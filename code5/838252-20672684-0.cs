    Action:
        public ActionResult Index()
        {
            ViewBag.CartData = _repository.GetCartData();
            ViewBag.LoginData = _repository.GetLoginData();
            
            return View();
        }   
    View:
        @foreach (var item in ViewBag.CartData)
        {         
            // Do something here with item in CartData model    
        }
        @foreach (var item in ViewBag.LoginData)
        {         
            // Do something here with item in LoginData model    
        }

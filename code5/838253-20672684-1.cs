    Action:
        public ActionResult Index()
        {
            ViewData["CartData"] = _repository.GetCartData();
            ViewData["LoginData"] = _repository.GetLoginData();
    
            return View();
        }    
    View:
        @foreach (var item in ViewData["CartData"] as List<Cart>)
        {         
            // Do something here with item in CartData model    
        }
        @foreach (var item in ViewData["LoginData"] as List<Login>)
        {         
            // Do something here with item in LoginData model    
        }

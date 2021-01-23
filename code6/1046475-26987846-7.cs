    public ActionResult Index()
        { 
    
          MyViewModel model = new MyViewModel();
    
          // You linq query to populate model goes here
    
           return View(model);
    
        }

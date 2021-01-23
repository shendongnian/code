    public ActionResult Index()
    {
    
        var model = new MyViewModel{employee=new Employee(), dept=new Department()}
    
        return View(model);
    }

    public ActionResult Index()
    {
       var viewmodel = CustomerViewModel();
       return View(viewmodel);
    }
    
    private static CustomerViewModel ()
    {
        return new CustomerViewModel
        {
        ...
        ContactName = BusinessLogic.GetContactName("Microsoft");
        ContactTel = BusinessLogic.GetContactTel();
        }
    }

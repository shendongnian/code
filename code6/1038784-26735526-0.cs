    public ActionResult Index()
    {
       MyViewModel myViewModel = new MyViewModel();
       myViewModel.lstmembre = ....;
       myViewModel.1stassociation = ...;
       
       return View(myViewModel);    
    }

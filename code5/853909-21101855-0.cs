    public ActionResult Index()
    {
        ViewModel vm = new ViewModel();   // <-- obviously this is named as an example
        WebService.Service = ws = new WebService.Service();
        string name = ws.GetName();
        vm.Name = name;
        return View("Index", vm);
   
    }

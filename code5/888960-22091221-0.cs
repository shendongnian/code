    public ActionResult Index(int id)
    {
         var webserviceObject = webserviceProxy.GetMyObject(id);
         var vm = new MyViewModel();
         vm.Name = webserviceObject.Name;
         return view(vm);
    }

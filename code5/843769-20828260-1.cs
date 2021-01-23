    public ActionResult Index()
    {
         GroupTypeRepository groupTypeRepo = new GroupTypeRepository();
         var model = new MyViewModel();
         model.GroupTypeNames = groupTypeRepo.GetAll().ToList();
         model.SomeOtherProperty = "some other property value";
         
         return View("Groups", model);
    }

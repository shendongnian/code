    public ActionResult Create()
    {
      var vm=new CreateCustomerVM();
      vm.MidNames=GetMidNames();
      return View(vm);
    }
    private List<SelectListItem> GetMidNames()
    {
      return new List<SelectListItem> { 
        new SelectListItem { Value="Mr", Text="Mr"},
        new SelectListItem { Value="Ms", Text="Ms"},
      };
    }

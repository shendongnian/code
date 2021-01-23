    public ActionResult Create()
    {
      var vm=new CreateCarVM();
      vm.Categories=GetCategories();
      return View(vm);
    }
    private List<SelectListItem> GetCategories()
    {
      var list=new List<SelectListItem>();
      //2 items hard coded for demo. You may load it from db
      list.Add(new SelectListItem { Value="1", Text="Sedan"});
      list.Add(new SelectListItem { Value="2", Text="SUV"});
      return list;
    }

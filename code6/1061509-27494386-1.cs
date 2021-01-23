    public ActionResult Search()
    {
      ViewModel model = new ViewModel();
      // populate properties including select lists
      return View(model);
    }
    [HttPost]
    public ActionResult Search(ViewModel model)
    {
      model.Items = // Get the filtered items based on the values of NameFilter, DeviceFilter and TypeFilter
      model.DeviceList = // reassign both select lists
      model.Typelist = ..
      return view(model);   
    }

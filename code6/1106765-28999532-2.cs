    public ActionResult Index()
    {
      List<Menu> model = new List<Menu>();
      // populate the collection (i.e. where parentID is null)
      // populate the sub menus for each menu item
        return View(model);
    } 

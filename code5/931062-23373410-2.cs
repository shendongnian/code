    public LayoutController
    {
      public ActionResult CreateMenu()
      {
        var model = db.getmenudata();
        return PartialView(model);
      }
    }

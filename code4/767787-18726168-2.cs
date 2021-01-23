    public ActionResult TopMenu()
    {
       MenuModel model = new MenuModel();
       //Add data to model using your method
       return PartialView("_TopMenu",model);
    }

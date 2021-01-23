    public ActionResult TopMenu()
    {
      var topMenu = return _menuService.GetTopMenu();
    
      //view model population code goes here
    
      return PartialView(viewModel);
    }

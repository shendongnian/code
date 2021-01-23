    public ActionResult TopMenu()
    {
      var topMenuTask = Task.Run(() => _menuService.GetTopMenuAsync());
      var topMenu = topMenuTask.Result;
      //view model population code goes here
      return PartialView(viewModel);
    }

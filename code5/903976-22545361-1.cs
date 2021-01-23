    public async Task<ActionResult> TopMenu()
    {
        var topMenu = await Task.Run<IEnumerable<TopMenuItem>>( () => { return _menuService.GetTopMenu(); });
    
        //view model population code goes here
    
        return PartialView(viewModel);
    }

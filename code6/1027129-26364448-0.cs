    [ChildActionOnly]
    public ActionResult AdminMenu()
    {
        var menu = _db.Menus.Include("MenuItems").First(m => m.Name == "Admin menu");
        var model = new MenuModelView
        {
            Name = menu.Name,
            CssClass = menu.CssClass,
            CssId = menu.CssId,
            Deleted = menu.Deleted,
            MenuItems = menu.MenuItems
        };
        return PartialView("_AdminMenu", model);
    }

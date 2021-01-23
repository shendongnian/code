    var menu = _db.Menus
                  .Include("MenuItems") // Or, use the typed version on newer EF's
                  .First(m => m.id == id); // Many LINQ expressions allow predicates
    return new MenuModelView
     {
        Menu = menu.Name,
        CssClass = menu.CssClass,
        CssId = menu.CssId,
        Deleted = menu.Deleted,
        MenuItems = menu.MenuItems
     }

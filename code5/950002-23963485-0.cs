    Dictionary<string, List<SelectListItem>> Permissions = 
      new Dictionary<string, List<SelectListItem>>();
    List<SelectListItem> PermissionLevels = new List<SelectListItem>();
    Permissions[ContactName] = new SelectListItem( ... ) // Repeat for each name
    ViewBag.Permissions = Permissions;

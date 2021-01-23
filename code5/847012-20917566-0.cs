     var vs = result.SkipWhile(a=> a.AccessRules==null).SelectMany(x => x.AccessRules, (a, b) => new MenuDetailsViewModel
        {
            MenuId = a.MenuId,
            DisplayText = a.DisplayText,
            MenuOrder = a.MenuOrder,
            HasKids = a.HasKids,
            MenuStatus = a.MenuStatus,
            AccessRuleLists = a.AccessRules.
                Select(c => new AccessRulesList { 
                    Id = b.Id, 
                    MenuId = b.Menu.MenuId, 
                    RoleId = b.Roles.RoleId,
                    CanCreate = b.CanCreate, 
                    CanUpdate = b.CanUpdate, 
                    CanDelete = b.CanDelete }).ToList()
        }).SingleOrDefault();

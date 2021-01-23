    parentMenu.Children = menus
        .Select(m => new AnotherMenuTypeYouNeedToCreate
        {
            ParentId = m.ParentId,
            MenuId = m.MenuId,
            Name = m.Name,
            Url = m.Url,
            Icon = m.Icon,
            ActivityView = m.ActivityView
        })
        .Where(m => m.ParentId == parentMenu.MenuId && m.ActivityView==true)
        .ToList<object>();

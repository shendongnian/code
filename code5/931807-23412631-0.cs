    return View(new UserNew {
        Roles = (from item in db.Roles
                 select item).Select(role => new RoleCheckbox {
                     Id = role.Id,
                     IsChecked = false,
                     Name = role.Name
                 }).ToList()
    });

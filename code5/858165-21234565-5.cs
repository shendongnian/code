    var menuSomeColumnsWithAnonymousObject = workunit.Menu.ListProjected(x => new
    {
        MenuID = x.MenuID,
        Path = x.Path,
        Name = x.Name
    }, x => x.Id == 1);
    var menuSomeColumnsWithDTO = workunit.Menu.ListProjected(x => new AdminMenuDTO
    {
        MenuID = x.MenuID,
        Path = x.Path,
        Name = x.Name
    }, x => x.Id == 1);

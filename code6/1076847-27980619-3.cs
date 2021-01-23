    foreach (var item in itemAdd)
    {
        Console.WriteLine(item.Roles);
        foreach (var childRoles in item.ChildRoles)
        {
            Console.WriteLine(childRoles);
        }
    }

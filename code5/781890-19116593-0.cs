    if (persons.Any()) 
    {
        // !HERE!
        foreach (var p in persons) 
        {
            p.IsAdmin = GetPermission(p.Email);
        }
        //Where you foreach it in a above method.
        return persons;
    }

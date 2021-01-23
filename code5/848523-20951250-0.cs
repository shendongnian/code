    var userGroups = up.GroupBy(u => u.Email).Where(g => g.Count() > 1);
    
    foreach(var group in userGroups)
    {
        Console.WriteLine("Following users have email {0}", group.Key);
        foreach(var user in group)
           Console.WriteLine(user);
    }
      

    using (var ctxt = new Core.BaseContext())
    {
        var user1 = new Core.SystemUser()
        {
            Forename = "Obsidian",
            Surname = "Phoenix"
        };
        ctxt.SystemUser.Add(user1);
        ctxt.SaveChanges();
    }
    using (var ctxt = new DerivedContext())
    {
        var user2 = new Core.SystemUser()
        {
            Forename = "John",
            Surname = "Doe"
        };
                
        ctxt.SystemUser.Add(user2);
        ctxt.SaveChanges();
        var users = ctxt.SystemUser.ToList();
        users.ForEach(u => Debug.WriteLine(string.Format("{0} {1}", u.Forename, u.Surname)));
        var order = new Order()
        {
            Id = 1,
            Item = "Test Item",
            Quantity = 1
        };
        ctxt.Orders.Add(order);
        ctxt.SaveChanges();
    }

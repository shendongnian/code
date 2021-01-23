    using (var db = new IdentityDbContext())
    {
        string tableName = "ApplicationUser";
        var type = Assembly.GetExecutingAssembly()
           .GetTypes().FirstOrDefault(t => t.Name == tableName);
        var method = db.GetType().GetMethods()
           .First(x => x.IsGenericMethod && x.Name == "Set");
        MethodInfo generic = method.MakeGenericMethod(type);
        var set = generic.Invoke(db, null);
    }

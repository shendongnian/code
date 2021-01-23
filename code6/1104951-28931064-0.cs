    using (var db = new MyDbContext)
    {
        string tableName = "ApplicationUser";
        var type = Assembly.GetExecutingAssembly()
           .GetTypes()
           .FirstOrDefault(t => t.Name == tableName);
        if(type != null)
        DbSet catContext = context.Set(type);    
    }

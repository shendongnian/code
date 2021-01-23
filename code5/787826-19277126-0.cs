    //Update ID 2
    using (var context = new Test2Context())
    {
        var items = context.MyTestClasses.Where(x => x.Id == 2).Count();
        var rowsAffected = context.Database.ExecuteSqlCommand("UPDATE MyTestClasses SET Name = 'Test2' WHERE Id = 2");
        Debug.WriteLine("--First Test--");
        Debug.WriteLine("items: {0}", items);
        Debug.WriteLine("rowsAffected: {0}", rowsAffected);
    }
    //Update all
    using (var context = new Test2Context())
    {
        var items = context.MyTestClasses.Count();
        var rowsAffected = context.Database.ExecuteSqlCommand("UPDATE MyTestClasses SET Name = 'Updated'");
        Debug.WriteLine("--Second Test--");
        Debug.WriteLine("items: {0}", items);
        Debug.WriteLine("rowsAffected: {0}", rowsAffected);
    }

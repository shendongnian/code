    protected override void Seed(MyContext context)
    {
        var listOfTables = new List<string> { "Table1", "Table2", "Table3" };
    
        foreach (var tableName in listOfTables)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + tableName + "]");
        }
    
        context.SaveChanges();
    
        // seed data below
    }

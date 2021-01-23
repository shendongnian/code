        using(var db = new DBModelContainer())
        {
           db.tblMyTable.MergeOption = MergeOption.NoTracking;
           // Narrow the scope of your db context
           db.AddTottblMyTable (item);
           db.SaveChanges();
        }

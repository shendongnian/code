    public void GetTwoResultSetsForUserId(int userId)
    {
        using (var db = new MyDbContext())
        {
            // Create a SQL command and add parameter
            var cmd = db.Database.Connection.CreateCommand();
            cmd.CommandText = "[dbo].[GetFooAndBarForUser]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@userId", userId));
    
            // execute your command
            db.Database.Connection.Open();
            var reader = cmd.ExecuteReader();
    
            // Read first model --> Foo
            var blogs = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<Foo>(reader, "Foo", MergeOption.AppendOnly);
    
            // move to next result set
            reader.NextResult();
    
            // Read second model --> Bar
            var bar = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<Post>(reader, "Bar", MergeOption.AppendOnly);
        }
    }      
    

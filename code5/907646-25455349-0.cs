    var workspace = new MetadataWorkspace(new[] { "res://*/" }, new[] { Assembly.GetExecutingAssembly() });
    using (var connection = new SqlConnection("data source=.;initial catalog=MultpleEdmxTest;integrated security=True;MultipleActiveResultSets=True"))
    {
        using (var entityConnection1 = new EntityConnection(workspace, connection, false))
        {
            using (var entityConnection2 = new EntityConnection(workspace, connection, false))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var schema1Entities = new Schema1Entities(entityConnection1))
                    {
                        schema1Entities.Database.UseTransaction(transaction);
                        // code goes here
                        schema1Entities.SaveChanges();
                    }
                    using (var schema2Entities = new Schema2Entities(entityConnection2))
                    {
                        schema2Entities.Database.UseTransaction(transaction);
                        // code goes here
                        schema2Entities.SaveChanges();
                    }
                    transaction.Commit();
                }
            }
        }
    }

    using (var connection = new SqlConnection(yourConnectionString))
    {
        connection.Open();
        using (var tx = connection.BeginTransaction())
        {
            foreach (var fooId in fooIds)
            {
                connection.Execute("UPDATE [dbo].[Foo] SET StatusType = 2 WHERE FooId = @id; INSERT INTO [dbo].[FooNotes] (FooId, Note) VALUES ('blah....', @id);", new {id = fooId}, tx);
            }
        
            tx.Rollback();
        }
    }

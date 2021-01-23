    using (var bulkCopy = new SqlBulkCopy(connection)) //using!
    {
        connection.Open();
        //explicit isolation level is best-practice
        using (var tran = connection.BeginTransaction(IsolationLevel.ReadCommitted))
        {
            bulkCopy.DestinationTableName = "table";
            bulkCopy.ColumnMappings...
            using (var dataReader = new ObjectDataReader<SomeObject>(paths))
            {
                //try
                //{
                bulkCopy.WriteToServer(dataReader, /*here you set some options*/);
                //}
                //catch(Exception ex){ ... } //you need no explicit try-catch here
            }
            tran.Commit(); //commit, will not be called if exception escapes
        }
    }

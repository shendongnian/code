    using (var sourceConnection = new SqlConnection("[SourceConnectionString]"))
    using (var destinationConnection = new SqlConnection("[DestinationConnectionString]"))
    {
        sourceConnection.Open();
        destinationConnection.Open();
        var sourceCommand = sourceConnection.CreateCommand()
        sourceCommand.CommandType = CommandType.Text;
        sourceCommand.CommandText = "SELECT * FROM [SourceTableName]";
        var sourceReader = sourceCommand.ExecuteReader();
        var bulkCopy = new SqlBulkCopy(destinationConnection)
        {
            DestinationTableName = "[DestinationTableName]",
            BatchSize = 100000
        };
        bulkCopy.WriteToServer(sourceReader);
    }

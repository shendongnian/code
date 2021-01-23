    using(var bcp = new SqlBulkCopy(connection))
    using(var reader = ObjectReader.Create(list, "Id", "Name", "Description"))
    { //           members to include, or omit for all ^^^^^^^^
        bcp.DestinationTableName = "SomeTable";
        bcp.WriteToServer(reader);
    }

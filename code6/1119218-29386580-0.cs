    DataTable table = new DataTable();
        //turn your CSV data into a DataTable using your favorite CSV parser.
        //My favorite is [`TextFieldParser`][2].
    
    using SqlBulkCopy copier = new SqlBulkCopy(connectionString,
                      SqlBulkCopyOptions.KeepIdentity Or SqlBulkCopyOptions.KeepNulls) {
        // Now set up your column mappings via SqlBulkCopy.ColumnMappings
        // Choose a destination table with SqlBulkCopy.DestinationTableName
    
        // execute the copy
        copier.WriteToServer(table);
    }

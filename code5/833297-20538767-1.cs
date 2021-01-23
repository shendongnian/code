    var table = reader.GetSchemaTable();
    foreach (DataRow column in table.Rows) //here each row represents a column
    {
        var allowsNull = column.Field<bool>("AllowDbNull"); //get it one by one here
        // similarly column.Field<string>("ColumnName") gives the name of the column
    }

    var tableName = "MyTableName";
    DataTable table = ds.Tables.Add(tableName);
    
    table.Columns.Add("firstColumnName", typeof(string));
    table.Columns.Add("secondColumnName", typeof(string));
    table.Columns.Add("thirdColumnName", typeof(string));
    table.Columns.Add("fourthColumnName", typeof(string));
    table.Columns.Add("fifthColumnName", typeof(string));
    table.Columns.Add("sixthColumnName", typeof(string));

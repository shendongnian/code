    DataSet ds = new DataSet();
    var excelConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path); 
    OleDbConnection connection = new OleDbConnection();
    connection.ConnectionString = excelConnectionString;
    
    DataTable sheets = GetSchemaTable(excelConnectionString);
    foreach (dataRow r in sheets.rows)
    {
        string query = "SELECT * FROM [" + r.Item(0).ToString + "]";
        ds.Clear();
        OleDbDataAdapter data = new OleDbDataAdapter(query, connection);
        data.Fill(ds);
    
    }

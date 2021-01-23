    DataTable dt = reader.GetSchemaTable();
    string query;
    List<string> list = new List<string>();
    foreach (DataRow columns in dt.Rows)
    {
       foreach (DataColumn properties in dt.Columns)
       {
           list.Add(properties.ColumnName + " " + properties.DataType);
       }
    }
    query = string.Join(",", list);

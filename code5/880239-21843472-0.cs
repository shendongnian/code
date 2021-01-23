    var reader = cmd.ExecuteReader();
    var schemaTable = reader.GetSchemaTable();
    var fields = new List<DDRow>();
    
    foreach (DataRow myField in schemaTable.Rows)
    {
        fields.Add(new DDRow()
        {
            ColumnName = Convert.ToString(myField["ColumnName"]),
            DataType = (SqlDbType)(int)myField["ProviderType"]
        });
    }
    

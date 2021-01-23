    foreach(DataRow row in tblCSV.Rows)
    {
        foreach(DataColumn col in tblCSV.Columns)
        {
            if(string.IsNullOrWhiteSpace(row.Field<string>(col)))
                row.SetField(col, "null");
        }
    }

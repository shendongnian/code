    private DataTable CreateDataTable(PropertyInfo[] properties)
    {
        DataTable dt = new DataTable();
        DataColumn dc = null;
        foreach (PropertyInfo pi in properties)
        {
            dc = new DataColumn();
            dc.ColumnName = pi.Name;
    
            if (pi.PropertyType.Name.Contains("Nullable"))
                dc.DataType = typeof(String);
            else
                dc.DataType = pi.PropertyType;
    
            // dc.DataType = pi.PropertyType;
            dt.Columns.Add(dc);
        }
        return dt;
    }

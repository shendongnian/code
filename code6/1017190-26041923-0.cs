    private DataTable ConvertToRegularDataTable(DataTable source)
    {
        DataTable result = new DataTable();
        foreach (DataColumn c in source.Columns)
        {
            result.Columns.Add(c.ColumnName, typeof(string));
        }
        DataColumn dc = new DataColumn("ID"); // table.Columns.Add("IdentityId", typeof(int));
        dc.AutoIncrement = true;
        dc.AutoIncrementSeed = 1;
        dc.AutoIncrementStep = 1;
        result.Columns.Add(dc);
        foreach (DataRow dr in source.Rows) 
        {
            result.Rows.Add(dr.ItemArray);
        }
        return result;
    }

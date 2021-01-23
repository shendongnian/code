    foreach (DataTable dt in ds.Tables)
    {
        List<DataColumn> columnsToDelete = new List<DataColumn>();
        foreach (DataColumn col in dt.Columns)
        {
            object first = dt.Rows[0][col];
            if (dt.AsEnumerable().Skip(1).All(r => r[col].Equals(first)))
            {
                columnsToDelete.Add(col);
            }
        }
        foreach (DataColumn colToRemove in columnsToDelete)
            dt.Columns.Remove(colToRemove);
    }

    DataTable dtAllString = new DataTable();
    foreach (DataColumn column in dt.Columns)
    {
        dtAllString.Columns.Add(column.ColumnName, typeof(string));
    }
    foreach (DataRow row in dt.Rows)
    {
        List<string> columnValues = new List<string>();
        foreach (DataColumn col in dt.Columns)
        {
            columnValues.Add(Convert.ToString(row[col]));
        }
        dtAllString.Rows.Add(columnValues.ToArray());
    }

    DataTable one = new DataTable();
    DataTable two = new DataTable();
    foreach (DataColumn col in DT.Columns)
    {
      if (!col.ColumnName.EndsWith("B"))
      {
        one.Columns.Add(col.ColumnName.Replace("_A", ""));
        foreach (DataRow row in DT.Rows)
        {
          one.Rows.Add(row[col.ColumnName]);
        }
      }
      else
      {
        one.Columns.Add(col.ColumnName.Replace("_B", ""));
        foreach (DataRow row in DT.Rows)
        {
          two.Rows.Add(row[col.ColumnName]);
        }
      }
    }

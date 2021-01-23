    private string GetRowValue(DataRow dr, string columnName)
    {
        if (dr.Table.Columns.Contains(columnName))
        {
            if ((!object.ReferenceEquals(dr[columnName], DBNull.Value)))
            {
                return Convert.ToString(dr[columnName]);
            }
        }
        return string.Empty;
    }

    public DataTable joinUniformTable(DataTable dt1, DataTable dt2)
    {
        int dt2ColsCount = dt2.Columns.Count;
        int dt1lRowsCount = dt1.Rows.Count;
        DataColumn column;
        for (int i = 0; i < dt2ColsCount; i++)
        {
            column = new DataColumn();
            string colName = dt2.Columns[i].ColumnName;
            System.Type colType = dt2.Columns[i].DataType;
            column.ColumnName = colName;
            column.DataType = colType;
            dt1.Columns.Add(column);
            for (int j = 0; j < dt1lRowsCount; j++)
            {
                dt1.Rows[j][colName] = dt2.Rows[j][colName];
            }
        }
        return dt1;
    }

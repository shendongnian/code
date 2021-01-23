    public static DataTable getTable(String sql, bool includeHeaderRow)
        {
            DataTable table = new DataTable();
            using (SqlDataAdapter adpt = new SqlDataAdapter(sql, getConn()))
            {
                adpt.Fill(table);
    
    
                if (includeHeaderRow)
                {    
                    DataTable dt = table.Clone();
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                      dt.Columns[i].DataType = typeof(Object);
                    }
                    foreach (DataRow row in table.Rows) 
                    {
                       dt.ImportRow(row);
                    }
                    DataRow headerRow = dt.NewRow();
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        headerRow[i] = table.Columns[i].ColumnName;
                    }
    
                    dt.Rows.InsertAt(headerRow, 0);
                }
            }
            return dt;
        }

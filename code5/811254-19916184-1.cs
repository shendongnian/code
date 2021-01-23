    DataTable allDTs = abc;
    int rowCount = allDTs.Rows.Count - 1;
    foreach (DataRow row in t2.Rows)
    {
        rowCount = rowCount + 1;
        allDTs.Rows.Add();
    
        int colCount = -1;
        foreach (DataColumn col in t2.Columns)
        {
            colCount = colCount + 1;
            if (colCount > allDTs.Columns.Count - 1) allDTs.Columns.Add(col.ColumnName);
            allDTs.Rows[rowCount][colCount] = row[col];
        }
    }
    
    rowCount = allDTs.Rows.Count - 1;
    foreach (DataRow row in t3.Rows)
    {
        rowCount = rowCount + 1;
        allDTs.Rows.Add();
    
        int colCount = -1;
        foreach (DataColumn col in t3.Columns)
        {
            colCount = colCount + 1;
            if (colCount > allDTs.Columns.Count - 1) allDTs.Columns.Add(col.ColumnName);
            allDTs.Rows[rowCount][colCount] = row[col];
        }
    }
    
    dataGridView1.DataSource = allDTs;

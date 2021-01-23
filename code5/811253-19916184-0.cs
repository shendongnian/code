    DataTable allDTs = abc;
    int colCount = allDTs.Columns.Count - 1;
    foreach (DataColumn col in t2.Columns)
    {
        colCount = colCount + 1;
        allDTs.Columns.Add(col.ColumnName);
    
        int rowCount = -1;
        foreach (DataRow row in t2.Rows)
        {
            rowCount = rowCount + 1;
            if (rowCount > allDTs.Rows.Count) allDTs.Rows.Add();
            allDTs.Rows[rowCount][colCount] = row[col];
        }
    }
    
    colCount = allDTs.Columns.Count - 1;
    foreach (DataColumn col in t3.Columns)
    {
        colCount = colCount + 1;
        allDTs.Columns.Add(col.ColumnName);
    
        int rowCount = -1;
        foreach (DataRow row in t3.Rows)
        {
            rowCount = rowCount + 1;
            if (rowCount > allDTs.Rows.Count) allDTs.Rows.Add();
            allDTs.Rows[rowCount][colCount] = row[col];
        }
    }
    
    dataGridView1.DataSource = allDTs;

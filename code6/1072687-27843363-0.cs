    // Create a temporary table
    DataTable dtNew = new DataTable();
    for(int i=0;dt.Columns.Count;i++)
    {
        dtNew.Columns.Add(dt.Columns[i].ColumnName,typeof(string));
    }
        
    
    // Add data to new table
    for(int i=0;dt.Rows.Count;i++)
    {
       dtNew.Rows.Add();
       for(int j=0;dt.Columns.Count;j++)
       {
          dtNew.Rows[i][j] = dt.Rows[i][j];
       }        
    }
    
    dt=null;
    dt=dtNew.Copy();

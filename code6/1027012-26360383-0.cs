    DataTable gridTable = (DataTable)dataGridView1.DataSource;
    
    DataTable dt = gridTable.Clone();
  
    foreach(DataRow row in gridTable.Rows)
    {
        dt.ImportRow(row);
    }

    DataTable gridTable = (DataTable)dataGridView1.DataSource;
    
    //create data table with the same schema as gridTable !
    DataTable dt = gridTable.Clone();
  
    foreach(DataRow row in gridTable.Rows)
    {
        //import every row from the gridTable to the new DataTable.
        dt.ImportRow(row);
    }

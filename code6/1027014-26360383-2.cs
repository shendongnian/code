    DataTable gridTable = (DataTable)dataGridView1.DataSource;
    
    //you can call AcceptChanges() if you want !
    
    //create data table with the same schema as gridTable !
    DataTable dt = gridTable.Clone();
  
    foreach(DataRow row in gridTable.Rows)
    {
        if(row.RowState == DataRowState.Deleted)
           continue;
        //import every row from the gridTable to the new DataTable.
        dt.ImportRow(row);
    }

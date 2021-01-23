    DataTable First_Table = new DataTable();
    DataTable Second_Table = new DataTable();
  
     for(int i =0 ; i<Frist_Table.Rows.Count; i++)
      {
             Second_Table.Rows[i]["Column_name"] =First_Table.Rows[i];["Column_name"]
       }
    Second_Table.AcceptChanges();

    DataTable dt=new DataTable();
    
    dt.Columns.Add("No",typeof(int));
    
    dt.Columns.Add("Item",typeof(string));
    
    dt.Columns.Add("quantity",typeof(int));
    
    dt.Columns.Add("Price",typeof(decimal));
    
    //Add row to the datatable
    
    for (int i = 0; i < count; i++)
    {
    
    //Not Sure what dtr is you looping through
    
        string no = dtr.Rows[i][0].ToString();
        string item = dtr.Rows[i][1].ToString() + " " + dtr.Rows[i][1].ToString();
        string A_qty = dtr.Rows[i][2].ToString();
        string price = dtr.Rows[i][3].ToString();
    
        dt.Rows.Add(no, item, A_qty, price);        
    }
    
    
    //Create New DataGridViewTextBoxColumn
    DataGridViewTextBoxColumn textboxColumn=new DataGridViewTextBoxColumn();
    
    //Bind DataGridView to Datasource
    dataGridView1.datasource=dt;
    
    //Add TextBoxColumn dynamically to DataGridView
     dataGridView1.Columns.Add(textboxColumn);
    
    //Loop through DataGridView
     foreach (DataGridViewRow row in dataGridView1.Rows)
      
    {
            
         //Do your task here
          string fourthColumn = row.Cells[4].Value.toString();
        
       }

    dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
    string searchValue = "test";
    
    for (int row = 0; row < dataGridView1.Rows.Count; ++row)
    {
     for (int col = 0; col < dataGridView1.Columns.Count; ++col)
     {
      var cellValue = dataGridView1.Rows[row].Cells[col].Value;
      
      if (cellValue != null && cellValue.ToString().Equals(searchValue))
      {
       dataGridView1.Rows[row].Cells[col].Selected = true;
       
       // if you want to search every cell for the searchValue then you shouldn't break.
       // break;
      } 
     }
    }

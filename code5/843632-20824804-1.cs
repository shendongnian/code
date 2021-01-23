    foreach (DataGridViewRow row in grid_stock.Rows) 
    {
      if (row.Cells[0].Value.Equals("StockID")) 
      {
        grid_stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        row.DefaultCellStyle.BackColor = Color.Red; 
      }
    }

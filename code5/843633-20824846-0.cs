    for (int i = 0; i < grid_stock.Rows.Count; i++)
    {
        if(grid_stock.Rows[i].Cells[stockID_column_index].Value == received_stockID) // Check if the row IDs match here
        {
            grid_stock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.grid_stock.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            break;
        }
    }

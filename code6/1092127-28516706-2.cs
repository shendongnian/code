    private void DGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        int col = e.ColumnIndex;
        myCheckedCell column = DGV.Columns[col] as myCheckedCell;
        if (column != null) 
        {
          Console.WriteLine(column.IsChecked.ToString());
          column.IsChecked = !column.IsChecked;
        }
    } 

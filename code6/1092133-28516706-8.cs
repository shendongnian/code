    private void DGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        int col = e.ColumnIndex;
        myCheckedColumn column = DGV.Columns[col] as myCheckedColumn ;
        if (column != null) 
        {
          Console.WriteLine(column.IsChecked.ToString());
          column.IsChecked = !column.IsChecked;
        }
    } 

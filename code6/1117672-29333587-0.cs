    private void dgv_CellClickMouse(object sender, 
                                    DataGridViewCellMouseEventArgs e)
    {
        DataGridView dgv = sender as DataGridView;
        int column = e.ColumnIndex;
        int row = e.RowIndex;
        if(column == -1 || row == -1)
        {
            // for debug purpose...
            Console.WriteLine("Not a valid row/column");
            return;
        }
        
        DataGridViewCell cell = dgv[column, row];
        if (cell != null)
        {
            
           ...... 
        }
    }

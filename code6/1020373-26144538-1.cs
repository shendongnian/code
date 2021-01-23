    private void placesGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        Boolean bl;
        if (placesGridView.Columns[e.ColumnIndex].Name == "name of check column")
        {
            DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)placesGridView.Rows[e.RowIndex].Cells[2]; //2 number of check column
               
                //bl is the check box current condition.
                //Change only this in your list eg list[e.RowIndex] = bl; No need to check all rows.
                bl = (Boolean)checkCell.Value; 
                     
            }
        }
        private void placesGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            
            if (placesGridView.IsCurrentCellDirty)
            {
                placesGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        
        }

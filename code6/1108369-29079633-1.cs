    void switchCellType(object sender, DataGridViewCellCancelEventArgs e)
    {
        DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
        // fill the drop down items..
        c.Items.Add("1");  // use
        c.Items.Add("2");  // your 
        c.Items.Add("3");  // code here!
        DGV[e.ColumnIndex, e.RowIndex] = c;  // change the cell
        DGV_CellBeginEdit(sender, e);        // restart the edit with the original parms  
    }
    private void DGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        DataGridViewCell cell = DGV[e.ColumnIndex, e.RowIndex];
        if (!(cell is DataGridViewComboBoxCell))
        {
            e.Cancel = true;
            switchCellType(sender, e);
            return;
        }
        //..

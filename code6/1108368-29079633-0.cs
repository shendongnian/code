    void switchCellType(object sender, DataGridViewCellCancelEventArgs e)
    {
        DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
        c.Items.Add("1");
        c.Items.Add("2");
        c.Items.Add("3");
        DGV[e.ColumnIndex, e.RowIndex] = c;
        DGV_CellBeginEdit(sender, e);
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

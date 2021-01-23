    private void Gridview_Output_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewCell cell = Gridview_Output[e.ColumnIndex, e.RowIndex];
        cell.Style.ForeColor = Color.Red;
    }

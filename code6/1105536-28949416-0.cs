    private void SinglesGridView_CellPainting(object sender,
    System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == 1 && 
            e.RowIndex >= 0 &&
            Convert.ToInt32(SinglesGridView[e.ColumnIndex, e.RowIndex].Value) > 100)
        e.CellStyle.BackColor = Color.Red;
    }

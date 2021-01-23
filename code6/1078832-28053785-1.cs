    void OnGridCellPainting(object sender, System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == mLastSortColumnIndex)
            e.CellStyle.BackColor = Color.LightGray;
    }

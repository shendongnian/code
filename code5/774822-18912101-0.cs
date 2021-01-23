    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
           //Give the relevant column index where pop up windows needs to be opened.
        if (e.ColumnIndex.Equals(1))
        {
            //Getting the position of the current cell.
            Point loc = dataGridView1.PointToScreen(dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
        }
    }

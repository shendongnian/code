    //CellPainting event handler for your dataGridView1
    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
       if (e.ColumnIndex > -1 && e.RowIndex > -1 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn){
         if (e.Value == null || !(bool)e.Value) {
             e.PaintBackground(e.CellBounds, false);
             e.Handled = true;
         }
       }
    }
    //CellBeginEdit event handler for your dataGridView1
    private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e){
       if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn){
                object cellValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
                e.Cancel = cellValue == null || !(bool)cellValue;
       }
    }

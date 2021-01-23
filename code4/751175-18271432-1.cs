    //First, you have to be sure the whole third column is Visible.
    //CellPainting event handler for your dataGridView1
    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 2)//This is the Column index you want to hide.
            {                
                object o = e.RowIndex == -1 ? null : dataGridView1[e.ColumnIndex - 1,e.RowIndex].Value;
                if (o!=null &&!(bool)o || e.RowIndex == -1 || e.RowIndex == dataGridView1.RowCount - 1)
                {
                    e.Graphics.FillRectangle(new SolidBrush(dataGridView1.BackgroundColor), e.CellBounds);
                    if(e.RowIndex > -1) dataGridView1[e.ColumnIndex, e.RowIndex].ReadOnly = true;
                    e.Handled = true;
                }
                if (o != null && (bool)o)
                {
                    dataGridView1[e.ColumnIndex, e.RowIndex].ReadOnly = false;                    
                }
            }
        }
    //CellContentClick event handler for your dataGridView1
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
       UpdateThirdColumCell(e);
    }
    //CellContentDoubleClick event handler for your dataGridView1
    private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
       UpdateThirdColumCell(e);
    }
    private void UpdateThirdColumCell(DataGridViewCellEventArgs e)
    {
            if (e.ColumnIndex == 1)//The column index of the CheckBox column
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGridView1[e.ColumnIndex, e.RowIndex];
                cell.Value = cell.EditingCellFormattedValue;
                dataGridView1.Invalidate();
                if ((bool)cell.Value)
                {
                    dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex + 1, e.RowIndex];
                }
            }
    }
    //CellStateChanged event handler for your dataGridView1
    private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
    {
        if (e.Cell.ColumnIndex == 2 && e.Cell.Selected)
        {
            dataGridView1.BeginEdit(false);
        }
    }

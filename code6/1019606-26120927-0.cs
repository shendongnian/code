    //subscribing the event
    dataGridView1.CellPainting += dataGridView1_CellPainting;
    
    //handle the event
    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
    
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            e.Graphics.DrawLine(Pens.Red, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Bottom);
            e.Graphics.DrawLine(Pens.Blue, e.CellBounds.Left, e.CellBounds.Top+e.CellBounds.Height / 2, e.CellBounds.Right,e.CellBounds.Top+ e.CellBounds.Height / 2);
    
            e.Paint(e.ClipBounds, DataGridViewPaintParts.ContentForeground);
            e.Handled = true;
        }
    }

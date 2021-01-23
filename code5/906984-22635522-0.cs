    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
     {
     
        if (e.RowIndex >= 0 && e.ColumnIndex == 0 && Convert.ToInt32(e.Value.ToString()) > 0)
        {
            e.PaintBackground(e.ClipBounds, false);
           dataGridView1[e.ColumnIndex, e.RowIndex].ToolTipText = e.Value.ToString();
           PointF p = e.CellBounds.Location;
           p.X += imageList1.ImageSize.Width;
     
          e.Graphics.DrawImage(imageList1.Images[0], e.CellBounds.X, e.CellBounds.Y, 16, 16);
           e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, p);
           e.Handled = true;
        }
     
    }

    private void dgvLogDetails_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == 0)
        {
            Bitmap image = imgList.Images[1];//Get the image somewhow
            bool selected = e.State.HasFlag(DataGridViewElementStates.Selected);
            e.PaintBackground(e.ClipBounds, false);
            PointF p = e.CellBounds.Location;
            p.X += image.Size.Width + 8;
            if (selected)
            {
                RectangleF newRect = new RectangleF(new PointF(e.CellBounds.Left + image.Size.Width, e.CellBounds.Top), new SizeF(e.CellBounds.Width - image.Size.Width, image.Height));
                 using(SolidBrush brush = new SolidBrush(e.CellStyle.SelectionBackColor))
                     e.Graphics.FillRectangle(brush, newRect);
            }
            e.Graphics.DrawImage(imgList.Images[1], e.CellBounds.X+4, 
                                                 e.CellBounds.Y, 16, 16);
            e.Graphics.DrawString(e.Value.ToString(), 
                                            e.CellStyle.Font, Brushes.Black, p);
            e.Handled = true;
        }
    }

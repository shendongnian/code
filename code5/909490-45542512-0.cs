    private void DgvCalendar_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                int columnIndex = 0;
    
                if (e.RowIndex >= 0 && e.ColumnIndex >= columnIndex)
                {
                    if (e.ColumnIndex % 2 == 0)
                    {
                        var brush = new SolidBrush(dgvCalendar.ColumnHeadersDefaultCellStyle.BackColor);
    
                        e.Graphics.FillRectangle(brush, e.CellBounds);
    
                        brush.Dispose();
    
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentBackground);
    
                        ControlPaint.DrawBorder(e.Graphics, e.CellBounds,
                            System.Drawing.Color.Transparent, 1, ButtonBorderStyle.Solid,
                            System.Drawing.Color.Transparent, 1, ButtonBorderStyle.Solid,
                            System.Drawing.Color.CornflowerBlue, 1, ButtonBorderStyle.Solid,
                            System.Drawing.Color.Transparent, 1, ButtonBorderStyle.Solid);
    
                        e.Handled = true;
                    }
                }
    
                if (e.RowIndex == -1 && e.ColumnIndex >= columnIndex)
                {
                    if (e.ColumnIndex % 2 == 0)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
    
                        ControlPaint.DrawBorder(e.Graphics, e.CellBounds,
                              System.Drawing.Color.Transparent, 1, ButtonBorderStyle.Solid,
                              System.Drawing.Color.Transparent, 1, ButtonBorderStyle.Solid,
                              System.Drawing.Color.CornflowerBlue, 1, ButtonBorderStyle.Solid,
                              System.Drawing.Color.Transparent, 1, ButtonBorderStyle.Solid);
    
                        e.Handled = true;
    
                        e.Handled = true;
                    }
                }
            }

    private void dataGridView1_CellPainting(object sender,
                                            DataGridViewCellPaintingEventArgs e)
    {
       if (e.ColumnIndex == yourImageColumnIndex)
       {
         e.Graphics.DrawImage((Bitmap)e.FormattedValue, e.CellBounds.X, e.CellBounds.Y);
         e.Graphics.DrawString(yourText, dataGridView1.Font, Brushes.Yellow,
                                                        e.CellBounds.X, e.CellBounds.Y);
         e.Handled = true;
       }
    }

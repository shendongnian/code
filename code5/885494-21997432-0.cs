    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex != -1 && e.Value != null && e.Value.ToString().Length > 5 && e.ColumnIndex == InterestedColumnIndex)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected);
            }
            if ((e.PaintParts & DataGridViewPaintParts.ContentForeground) != DataGridViewPaintParts.None)
            {
                string text = e.Value.ToString();
                string textPart1 = text.Substring(0, text.Length - 5);
                string textPart2 = text.Substring(text.Length - 5, 5);
                Size fullsize = TextRenderer.MeasureText(text,e.CellStyle.Font);
                Size size1 = TextRenderer.MeasureText(textPart1, e.CellStyle.Font);
                Size size2 = TextRenderer.MeasureText(textPart2, e.CellStyle.Font);
                Rectangle rect1 = new Rectangle(e.CellBounds.Location, e.CellBounds.Size);
                using (Brush cellForeBrush = new SolidBrush(e.CellStyle.ForeColor))
                {
                    e.Graphics.DrawString(textPart1, e.CellStyle.Font, cellForeBrush, rect1);
                }
                rect1.X += (fullsize.Width - size2.Width);
                rect1.Width = e.CellBounds.Width;                    
                e.Graphics.DrawString(textPart2, e.CellStyle.Font, Brushes.Crimson, rect1);
            }
        }
    }

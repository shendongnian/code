    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex != -1 && e.Value != null && e.Value.ToString().Length > 5 && e.ColumnIndex == 2)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected);
            }
            if ((e.PaintParts & DataGridViewPaintParts.ContentForeground) != DataGridViewPaintParts.None)
            {
                bool rightToLeft = this.RightToLeft == RightToLeft.Yes ? true:false;
                string text = e.Value.ToString();
                string textPart1 = text.Substring(0, text.Length - 5);
                string textPart2 = text.Substring(text.Length - 5, 5);
                Size fullsize = TextRenderer.MeasureText(text, e.CellStyle.Font);
                Size size1 = TextRenderer.MeasureText(textPart1, e.CellStyle.Font);
                Size size2 = TextRenderer.MeasureText(textPart2, e.CellStyle.Font);
                Rectangle rect1 = new Rectangle(e.CellBounds.Location, e.CellBounds.Size);
                TextFormatFlags flags = GetFlagsForCellStyleAlignment(rightToLeft, e.CellStyle.Alignment);
                TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font, rect1, Color.Crimson, flags);
                using (Brush cellForeBrush = new SolidBrush(e.CellStyle.ForeColor))
                {
                    TextRenderer.DrawText(e.Graphics, textPart1, e.CellStyle.Font, rect1, e.CellStyle.ForeColor, flags);
                }
            }
        }
    }
    TextFormatFlags GetFlagsForCellStyleAlignment(bool rigthToLeft, DataGridViewContentAlignment alignment)
    {
        TextFormatFlags flags = TextFormatFlags.Default;
        switch (alignment)
        {
            case DataGridViewContentAlignment.TopLeft:
                {
                    flags = TextFormatFlags.Default;
                    if (rigthToLeft)
                    {
                        flags |= TextFormatFlags.Right;
                    }
                    break;
                }
            case DataGridViewContentAlignment.MiddleLeft:
                {
                    flags = TextFormatFlags.VerticalCenter;
                    if (rigthToLeft)
                    {
                        flags |= TextFormatFlags.Right;
                    }
                    break;
                }
        }
        if (rigthToLeft)
            flags |= TextFormatFlags.RightToLeft;
        return flags;
    }

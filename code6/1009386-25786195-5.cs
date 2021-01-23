    Label imageLabel;
    void showImageLabel(DataGridViewCellPaintingEventArgs e)
    {
        if (imageLabel == null) imageLabel = new Label();
        imageLabel.Text = "";
        imageLabel.Parent = dataGridView1;
        imageLabel.Location =  e.CellBounds.Location;
        if (imageLabel.Image != null) imageLabel.Image.Dispose();
        Size size = ((Bitmap)e.Value).Size;
        Size newSize = new Size( (int)(size.Width * 1.5f), (int)(size.Height * 1.5f));
        Bitmap bmp = new Bitmap((Bitmap)e.Value, newSize);
        imageLabel.Size = newSize;
        imageLabel.Image = bmp; 
        imageLabel.Show();
    }
    private void dataGridView1_CellPainting(object sender, 
                                            DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 | e.ColumnIndex < 0) return;
        if (e.Value == null) return;
        if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
        {
            if (e.Value.GetType() == typeof(Bitmap))
            {
                showImageLabel(e);
                e.Handled = true;
                return;
            }
            else if (imageLabel != null) imageLabel.Hide();
            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.CellBounds);
            e.Graphics.DrawString(e.FormattedValue.ToString(), 
                   new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size * 1.5f), 
                   SystemBrushes.HighlightText, e.CellBounds.Location);
            e.Handled = true;
        }
    }

    Label imageLabel;
    bool labelHide = false;                                                     //*** new
    void showImageLabel(DataGridViewCellPaintingEventArgs e)
    {  
        if (labelHide)  return;                                                 //*** new
        if (imageLabel == null) imageLabel = new Label();
        imageLabel.Click += (sender, evt) => 
                            { ((Label)sender).Hide(); labelHide = true; };     //*** new
        imageLabel.Text = "";
        imageLabel.Parent = dataGridView1;
        imageLabel.Location =   e.CellBounds.Location; 
        if (imageLabel.Image != null) imageLabel.Image.Dispose();
        //Size size = ((Bitmap)e.Value).Size;                                   //*** old
        Size size = ((Bitmap)e.FormattedValue).Size;                            //*** new
        Size newSize = new Size( (int)(size.Width * 1.5f), (int)(size.Height * 1.5f));
        //Bitmap bmp = new Bitmap((Bitmap)e.Value, newSize);                    //*** old
        Bitmap bmp = new Bitmap((Bitmap)e.FormattedValue, newSize);             //*** new
        imageLabel.Size = newSize;
        imageLabel.Image = bmp; 
        imageLabel.Show();
    }
    private void dataGridView1_CellPainting(object sender, 
                                            DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 | e.ColumnIndex < 0) return;
        if (e.Value == null) { if (imageLabel != null) imageLabel.Hide(); return; }
        if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
        {
            //if (e.Value.GetType() == typeof(Bitmap))                          //*** old
            if (e.FormattedValue.GetType() == typeof(Bitmap))                   //*** new
            {
                showImageLabel(e);
                e.Handled = true;                                               //*** old
                if (labelHide) labelHide = false; else e.Handled = true;        //*** new
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
    private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
    {
        if (imageLabel != null) imageLabel.Hide();
    }

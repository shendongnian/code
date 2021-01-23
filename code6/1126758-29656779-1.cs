    private void ultraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
    {
        // Check if this is data row -  if you have summaries, groups...
        if (e.Row.IsDataRow)
        {
            // Create an image from the path string in the "Path" cell
            Image image = Bitmap.FromFile(e.Row.Cells["Path"].Text);
    
            // Put the image in the "Image" cell
            e.Row.Cells["Image"].Value = image;
        }
    }

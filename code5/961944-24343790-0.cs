    byte[] bArray = GetRawImageBytes();
    // Get an image object from the byte-array
    Image ddbImage;
    using (var ms = new MemoryStream(bArray, 0, bArray.Length))
    {
        ms.Write(bArray, 0, bArray.Length);
        ddbImage = Image.FromStream(ms, true);
    }
            
    // Create a 100x100 thumbnail from the image
    var ThumbnailSize = new Size(100, 100);
    var thumb = ddbImage.GetThumbnailImage(
                ThumbnailSize.Height, 
                ThumbnailSize.Width, 
                null, IntPtr.Zero);
    // Create an image column for the datagridview
    var imgColumn = new DataGridViewImageColumn
    {
        HeaderText = "Image", 
        Name = "img"
    };
            
    dataGridView1.Columns.Add(imgColumn);
            
    // Add the first row, using this image
    dataGridView1.Rows.Add();
    dataGridView1.Rows[0].Cells[0].Value = thumb;
    // lets set the gridview-height to the thumbnail height
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        row.Height = ThumbnailSize.Height;
    }

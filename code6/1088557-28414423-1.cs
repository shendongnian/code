    Image image = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value as Image;
    if(image != null)
    {
        MemoryStream ms = new MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.);
        byte[] imagedata = ms.ToArray();
    }

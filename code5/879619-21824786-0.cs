    //Save content of imageBytes to db VARBINARY(MAX) 
    byte[] imageBytes;
    using (imgStr = new System.IO.MemoryStream())
    {
        pictureBox.Image.Save(imgStr, System.Drawing.Imaging.ImageFormat.Jpeg); // Depending on your format.
        imageBytes = imgStr.ToArray();
    }
    
    //to load from db use
    using (Stream imgStr = new MemoryStream(imageBytes))
    {
        pictureBox.Image = System.Drawing.Image.FromStream(imgStr);
    }

    System.Drawing.Image image = (System.Drawing.Image)rw[3];
    using(var memoryStream = new MemoryStream())
    {
        image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
    }

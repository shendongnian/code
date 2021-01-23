    using (MemoryStream m = new MemoryStream())
    {
        myObject.image.Save(m, image.RawFormat); //u can use System.Drawing.Imaging.ImageFormat.Jpeg or whatever ur image type is
        ...
    }

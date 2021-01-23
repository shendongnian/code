    public byte[] imageToByteArray(System.Drawing.Image image)
    {
       using (MemoryStream ms = new MemoryStream())
       {
           image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
           return ms.ToArray();
       }
    }

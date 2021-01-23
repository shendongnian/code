    public static void byteArrayToImage(byte[] data)
    {
         using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
         {
             Image img=Bitmap(Image.FromStream(ms));
             img.Save(@"D:\image.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
         }
    }

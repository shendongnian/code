      private static byte[] imageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageIn.Dispose();
                return ms.ToArray();
            }
        }

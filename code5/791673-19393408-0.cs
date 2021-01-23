    public static byte[] imageToByteArray(System.Drawing.Image sourceImage)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            sourceImage.Save(memoryStream, sourceImage.RawFormat);
            
            return memoryStream.ToArray();
        }

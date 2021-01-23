    public static byte[] GetByteFromFile(string FullPath)
        {
            byte[] ImageData = null;
            if (System.IO.File.Exists(FullPath))
            {
                System.IO.FileStream fs = new System.IO.FileStream(FullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                ImageData = new byte[fs.Length];
                fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
            }
            return ImageData;
        }

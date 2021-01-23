        public byte[] ConvertToBlob(String path)
        {
            FileStream fs = new FileStream(path,
            FileMode.OpenOrCreate, FileAccess.Read);
            byte[] rawData = new byte[fs.Length];
            fs.Read(rawData, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
           
            return rawData;
        }

    // **** Read File/Image into Byte Array from Filesystem
            public static byte[] GetPhoto(string filePath)
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
    
                byte[] photo = br.ReadBytes((int)fs.Length);
    
                br.Close();
                fs.Close();
    
                return photo;
            }

       public List<SiteDetail> Read(string filePath)
       {
           if (File.Exists(FileName))
            {
                Stream stream= File.OpenRead(filePath);
                BinaryFormatter deserializer = new BinaryFormatter();
                var details= (List<SiteDetail>)deserializer.Deserialize(stream);
                stream.Close();
                return details;
            }
            return null; // file not exists
       }

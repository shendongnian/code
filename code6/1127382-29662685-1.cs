        public T BinaryFileDeSerialize<T>(string filePath)
        {
            FileStream fileStream = null;
            Object obj;
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The file" + " was not found. ", filePath);
                
            using(var fileStream = new FileStream(filePath, FileMode.Open))
            {
               BinaryFormatter b = new BinaryFormatter(); 
               obj = b.Deserialize(fileStream);
            }
            return (T)obj;
        }

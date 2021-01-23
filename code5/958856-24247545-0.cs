        public static void SerializeToBin(object obj, string filename)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filename));
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                bf.Serialize(fs, obj);
            }
        }
        public static T DeSerializeFromBin<T>(string filename) where T : new()
        {
            if (File.Exists(filename))
            {
                T ret = new T();
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    ret = (T)bf.Deserialize(fs);
                }
                return ret;
            }
            else
                throw new FileNotFoundException(string.Format("file {0} does not exist", filename));
        }

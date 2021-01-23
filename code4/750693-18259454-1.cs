    [Serializable]
        public class BaseClass: ICloneable
        {
            /*
            Base Class Mumbers ...
            */
    
            public object Clone()
            {
                var bf = new BinaryFormatter();
                using (Stream str = new MemoryStream())
                {
                    bf.Serialize(str, this);
                    str.Seek(0, SeekOrigin.Begin);
                    return bf.Deserialize(str);
                }
            }
        }

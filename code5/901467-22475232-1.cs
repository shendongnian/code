    public class Person : ICloneable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Address PersonAddress { get; set; }
    
        public object Clone()
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, this);
    
                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult;
        }
    }

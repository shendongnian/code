[DataContract]
    public class TestObject
    {
        private int _id;
        private string _name;
        private decimal _number;
        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        [DataMember]
        public decimal Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }
    }
private string jsonText = "{\"Id\": 1, \"Name\": \"kanozuki\", \"Number\":\"0100\"}";
TestObject obj = Deserialise<TestObject>(jsonText);
public T Deserialise<T>(string json)
        {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                T result = (T)deserializer.ReadObject(stream);
                return result;
            }
        }</code>
    
Results:
Id:1
Name:kanozuki
Number: 100

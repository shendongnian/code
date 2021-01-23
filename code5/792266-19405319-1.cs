    public interface IMyClass
    {
        void SetMyVariable(int value);
    }
    public class MyClass : IMyClass
    {
        public int MyVariable;
        public MyClass()
        {
            MyVariable = 10;
        }
        public void SetMyVariable(int value)
        {
            this.MyVariable = value;
        }
    }
    public class MyParentClass
    {
        public IMyClass IMyClass { get; set; }
    }
    
    public class MyClassConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            var jsonObject = JObject.Load(reader);
            var value = new MyClass();
            if (value == null)
            {
                throw new JsonSerializationException("No object created.");
            }
            serializer.Populate(jsonObject.CreateReader(), value);
            return value;
        }
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return typeof(IMyClass).IsAssignableFrom(objectType);
        }
    }
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestSerializer()
        {
            var myClass = new MyParentClass { IMyClass = new MyClass() };
            var serializedClass = JsonConvert.SerializeObject(myClass);
            var result = JsonConvert.DeserializeObject<MyParentClass>(serializedClass, new MyClassConverter());
            Assert.IsNotNull(result);
        }
    }
    
    

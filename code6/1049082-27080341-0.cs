    public class MyCustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (MyEvent);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            existingValue = new MyEvent(new MyEntityId(jObject["Id"]["Value"].ToString()), jObject["Name"].ToString());
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class MyEvent
    {
        public MyEntityId Id { get; set; }
        public string Name { get; set; }
        public MyEvent(MyEntityId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    public class MyEntityId : MyIdentity
    {
        public MyEntityId(string identityValue)
            : base(identityValue)
        {
        }
    }
    public abstract class MyIdentity
    {
        protected readonly bool convertableAsGuid;
        protected readonly string value;
        public string Value { get { return this.value; } }
        public MyIdentity(string identityValue)
        {
            this.value = identityValue;
            Guid guid;
            if (Guid.TryParse(identityValue, out guid))
                this.convertableAsGuid = true;
        }
    }

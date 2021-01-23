    static void Main(string[] args)
    {
        var evnt = new MyEvent(new MyEntityId(Guid.NewGuid().ToString()), "Jon Doe");
        var eventHeaders = new Dictionary<string, object>
            {
                {"EventClrTypeName", evnt.GetType().AssemblyQualifiedName}
            };
        var serializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None };
        var metadata = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eventHeaders, serializerSettings));
        var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(evnt, serializerSettings));
        string dataAsString = Encoding.UTF8.GetString(data);
        var eventClrTypeName = JObject.Parse(Encoding.UTF8.GetString(metadata)).Property("EventClrTypeName").Value;
        var obj = JsonConvert.DeserializeObject<MyEvent>(dataAsString, new JsonConverter[] {new MyCustomConverter()});
    }

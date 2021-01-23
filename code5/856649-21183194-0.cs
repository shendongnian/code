    public class IntegerConverter : JsonConverter
    {
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
        serializer.Serialize(writer, Convert.ToInt32(value));
      }
      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
        throw new NotImplementedException();
      }
      public override bool CanConvert(Type objectType)
      {
        return objectType == typeof(string);
      }
    }
    class TestJson
    {
      public string Field1 { get; set; }
      public string Field2 { get; set; }
      public string Field3 { get; set; }
      [JsonConverter(typeof(IntegerConverter))]
      public string Field4 { get; set; }        
    }

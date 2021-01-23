public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
{
    serializer.Converters.Remove(this);
    JToken jToken = JToken.FromObject(value, serializer);
    // Perform any necessary conversions on the object returned
}

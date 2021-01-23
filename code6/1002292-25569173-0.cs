    public class OrderJsonConverter : JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
    
    		var obj = value as Order;
            
    		writer.WritePropertyName("accountUri");
            serializer.Serialize(writer, obj.AccountID.ToString());
    		
    		writer.WritePropertyName("productUri");
            serializer.Serialize(writer, obj.ProductID.ToString());
    		
    		writer.WritePropertyName("Total");
            serializer.Serialize(writer, obj.Total);
    
            writer.WriteEndObject();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
    		throw new NotImplementedException();
        }
    
    	public override bool CanConvert(Type objectType)
    	{
    		return typeof(Order).IsAssignableFrom(objectType);
    	}
    }

    ///Custom converter to parse the container.
    public class ItemConverter : JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		var jobj = JObject.Load(reader);
    			
    		var item = jobj.First.First.ToObject<Item>();
    		var container = new ItemContainer
    		{
    			Name = jobj.First.Path,
                Data = item
    		};
    		return container;
    	}
    
    	public override bool CanConvert(Type objectType)
    	{
    		return objectType == typeof (Item);
    	}
    }
    
    [JsonConverter(typeof(ItemConverter))]
    public class ItemContainer
    {
    	public string Name { get; set; }
        //Your object is here
    	public Item Data { get; set; }
    }
    public class Item
    {
    	public string code { get; set; }
        //Other properties
    }
    
    public class RootObj
    {
    	public ItemContainer[] ShippingMethods { get; set; }
    }

    public class TestBaseConverter : JsonConverter
    {
    	public override object ReadJson(
    		JsonReader reader,
    		Type objectType,
    		object existingValue,
    		JsonSerializer serializer)
    	{
    		JObject obj = serializer.Deserialize<JObject>(reader);
    
    		TestBase result = null;
    		
    		if (obj["subtests"] != null)
    		{
    			result = new TestSuite();
    		}
    		else 
    		{
    			result = new Subtest();
    		}
    		
    		serializer.Populate(obj.CreateReader(), result);
    		
    		return result;
    	}
    	
    	public override bool CanConvert(Type objectType)
    	{
    		return typeof(TestBase).IsAssignableFrom(objectType);
    	}
    	
    	public override bool CanWrite
    	{
    		get { return false; }
    	}
    	
    	public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		throw new NotSupportedException();
    	}
    }

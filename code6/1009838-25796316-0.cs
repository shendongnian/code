    public class MyConverter : JsonConverter
    {
    	public override bool CanRead { get { return false; } }
    	
    	public override object ReadJson(
    		JsonReader reader,
    		Type objectType,
    		object existingValue,
    		JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    	
    	public override void WriteJson(
    		JsonWriter writer,
    		object value,
    		JsonSerializer serializer)
    	{
    		var someThing = (SomeThing)value;
    		
    		var things = typeof(SomeThing).GetProperties()
    			.Where(pr => pr.PropertyType.IsAssignableFrom(typeof(Thing)))
    			.ToDictionary (pr => pr.Name, pr => pr.GetValue(someThing));
    			
    		var nonThings = typeof(SomeThing).GetProperties()
    			.Where(pr => !pr.PropertyType.IsAssignableFrom(typeof(Thing)));
    			
    		writer.WriteStartObject();
    		writer.WritePropertyName("things");
    		serializer.Serialize(writer, things);
    		
    		foreach (var nonThing in nonThings)
    		{	
    			writer.WritePropertyName(nonThing.Name);
    			serializer.Serialize(writer, nonThing.GetValue(someThing));
    		}
    		
    		writer.WriteEndObject();
    	}
    	
    	public override bool CanConvert(Type type)
    	{
    		return type == typeof(SomeThing);
    	}
    }

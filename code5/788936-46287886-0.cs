    public class BaseClassConverter : JsonConverter
    	{
    		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    		{
    			var j = JObject.Load(reader);
    			var retval = BaseClass.From(j, serializer);
    			return retval;
    		}
    
    		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    		{
    			serializer.Serialize(writer, value);
    		}
    
    		public override bool CanConvert(Type objectType)
    		{
    			// important - do not cause subclasses to go through this converter
    			return objectType == typeof(BaseClass);
    		}
    	}
    
    	// important to not use attribute otherwise you'll infinite loop
    	public abstract class BaseClass
    	{
    		internal static Type[] Types = new Type[] {
    			typeof(Subclass1),
    			typeof(Subclass2),
    			typeof(Subclass3)
    		};
    
    		internal static Dictionary<string, Type> TypesByName = Types.ToDictionary(t => t.Name.Split('.').Last());
    
    		// type property based off of class name
    		[JsonProperty(PropertyName = "type", Required = Required.Always)]
    		public string JsonObjectType { get { return this.GetType().Name.Split('.').Last(); } set { } }
    
    		// convenience method to deserialize a JObject
    		public static new BaseClass From(JObject obj, JsonSerializer serializer)
    		{
    			// this is our object type property
    			var str = (string)obj["type"];
    
    			// we map using a dictionary, but you can do whatever you want
    			var type = TypesByName[str];
    
    			// important to pass serializer (and its settings) along
    			return obj.ToObject(type, serializer) as BaseClass;
    		}
    
    
            // convenience method for deserialization
    		public static BaseClass Deserialize(JsonReader reader)
    		{
    			JsonSerializer ser = new JsonSerializer();
    			// important to add converter here
    			ser.Converters.Add(new BaseClassConverter());
    
    			return ser.Deserialize<BaseClass>(reader);
    		}
    	}

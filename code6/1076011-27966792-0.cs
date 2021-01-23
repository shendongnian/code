    public class DataJsonConverter : JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		List<Tuple<string, JRaw>> jlist = ((List<Tuple<string, string>>)value).Select(t => new Tuple<string, JRaw>(t.Item1, new JRaw(t.Item2))).ToList();
    		serializer.Serialize(writer, jlist);
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		JArray jarray = JArray.Load(reader);
    		
    		List<Tuple<string, string>> result = new List<Tuple<string, string>>();
    		string item1;
    		string item2;
    		foreach (JObject j in jarray)
    		{
    			item1 = j.GetValue("Item1").ToString();
    			item2 = j.GetValue("Item2").ToString();
    			result.Add(new Tuple<string, string>(item1, item2));
    		}
    		return result;
    	}
    
    	public override bool CanConvert(Type objectType)
    	{
    		return typeof(List<Tuple<string, string>>).IsAssignableFrom(objectType);
    	}
    }
NewtonSoft already knows how to write `List<Tuple<string, JRaw>>` as Json I just needed to serialize it.
I also found it helpful to visit this [Json .Net Blog post][1], as well as this [post][2].
  [1]: https://json.codeplex.com/discussions/56031
  [2]: http://blog.maskalik.com/asp-net/json-net-implement-custom-serialization/

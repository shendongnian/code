    void Main()
    {
    	var a = A.Test();
    	SerialiseAllFields.Dump(a);
    }
    
    class A
    {
    	private int PrivField1;
    	private int PrivProp1 { get; set; }
    	private B PrivSubClassField1;
    
    	public static A Test()
    	{
    		return new A { PrivField1 = 1, PrivProp1 = 2, PrivSubClassField1 = B.Test() };
    	}
    }
    
    class B
    {
    	private int PrivField1;
    	private int PrivProp1 { get; set; }
    
    	public static B Test()
    	{
    		return new B { PrivField1 = 3, PrivProp1 = 4 };
    	}
    }
    
    // Define other methods and classes here
    public static class SerialiseAllFields
    {
    	public static void Dump(object o, bool indented = true)
    	{
    		var settings = new Newtonsoft.Json.JsonSerializerSettings() { ContractResolver = new AllFieldsContractResolver() };
    		if (indented)
    		{
    			settings.Formatting = Newtonsoft.Json.Formatting.Indented;
    		}
    		Newtonsoft.Json.JsonConvert.SerializeObject(o, settings).Dump();
    	}
    }
    
    public class AllFieldsContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
    	protected override IList<Newtonsoft.Json.Serialization.JsonProperty> CreateProperties(Type type, Newtonsoft.Json.MemberSerialization memberSerialization)
    	{
    		var props = type
    			.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
    			.Select(p => base.CreateProperty(p, memberSerialization))
    			.Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
    			.Select(f => base.CreateProperty(f, memberSerialization)))
    			.ToList();
    		props.ForEach(p => { p.Writable = true; p.Readable = true; });
    		return props;
    	}
    }

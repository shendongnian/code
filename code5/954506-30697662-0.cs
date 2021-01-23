    public class ForceJSONSerializePrivatesResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
	{
		protected override IList<Newtonsoft.Json.Serialization.JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
		{
			var props = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			
			List<Newtonsoft.Json.Serialization.JsonProperty> jsonProps = new List<Newtonsoft.Json.Serialization.JsonProperty>();
			
			foreach( var prop in props )
			{
			jsonProps.Add( base.CreateProperty(prop, memberSerialization));
			}
			
			foreach( var field in type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance) )
			{
			jsonProps.Add ( base.CreateProperty( field, memberSerialization ) );
			}
					       
			jsonProps.ForEach(p => { p.Writable = true; p.Readable = true; });
			return jsonProps;
		}
	}

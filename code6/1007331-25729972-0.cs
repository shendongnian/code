    using Newtonsoft.Json;
    namespace TestProject
    {
		[JsonObject(MemberSerialization.OptIn)]
		public class JSonData
		{
			[JsonProperty]
			public string data { get; set; }
			public JSonData()
			{
			}
			public string ToJsonString()
			{
				return JsonConvert.SerializeObject(this);
			}
			public static JSonData Deserialize(string jsonString)
			{
				return JsonConvert.DeserializeObject<JSonData>(jsonString);
			}
		}
	}

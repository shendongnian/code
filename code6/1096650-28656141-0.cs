	class Program
	{
		static void Main()
		{
			var root = new Root
			{
				Array = new[] { "element 1", "element 2", "element 3" },
				Object = new Obj
				{
					Property1 = "value1",
					Property2 = "value2",
				},
			};
			var settings = new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
			};
			settings.Converters.Add(new MyConverter());
			string json = JsonConvert.SerializeObject(root, settings);
			Console.WriteLine(json);
		}
	}
	public class Root
	{
		public string[] Array { get; set; }
		public Obj Object { get; set; }
	}
	public class Obj
	{
		public string Property1 { get; set; }
		public string Property2 { get; set; }
	}
	class MyConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(string[]) || objectType == typeof(Obj);
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteRawValue(JsonConvert.SerializeObject(value, Formatting.None));
		}
	}

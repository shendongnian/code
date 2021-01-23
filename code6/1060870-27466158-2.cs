    public class Day
	{
		public string morning_low { get; set; }
		public string daytime_high { get; set; }
	}
	
	[JsonConverter(typeof(Data.Converter))]
	public class Data
	{
		public string city_name { get; set; }
        public Dictionary<DateTime, Day> days { get; set; }
		public class Converter : JsonConverter
		{
			public override bool CanConvert(Type type) { return type == typeof(Data); }
            public override object ReadJson(JsonReader reader, Type type, object value, JsonSerializer serializer) 
			{
				Data obj = new Data();
				obj.days = new Dictionary<DateTime, Day>();
				DateTime v;
				while (reader.Read() && reader.TokenType != JsonToken.EndObject)
				{
					if (reader.TokenType != JsonToken.PropertyName)
						throw new JsonSerializationException("Unexpected token type");
					
					if ("city_name" == (string)reader.Value)
					{
						if (obj.city_name != null)
							throw new JsonSerializationException("Duplicate key: city_name");
						obj.city_name = reader.ReadAsString();
					}
					else if (DateTime.TryParseExact((string)reader.Value, serializer.DateFormatString, 
													serializer.Culture, DateTimeStyles.None, out v))
					{
						reader.Read();
						obj.days.Add(v, serializer.Deserialize<Day>(reader));
					}
					else
					{
						if (serializer.MissingMemberHandling == MissingMemberHandling.Error)
							throw new JsonSerializationException("Unexpected property: " + reader.Value);
						reader.Read();
						serializer.Deserialize(reader, reader.ValueType);
					}
				}
				return obj;
			}
			public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			{
				Data obj = (Data)value;
				writer.WriteStartObject();
				writer.WritePropertyName("city_name");
				writer.WriteValue(obj.city_name);
				foreach (var pair in obj.days)
				{
					writer.WritePropertyName(pair.Key.ToString(serializer.DateFormatString));
					serializer.Serialize(writer, pair.Value);
				}
				writer.WriteEndObject();
			}
		}
	}
	
	public class ResultContent
	{
		public Data data { get; set; }
	}
	
	public class ResultContentRoot
	{
		public ResultContent result_content { get; set; }
	}
	
	public static void Main()
	{
		var data = new Data();
		data.city_name = "New York";
        data.days = new Dictionary<DateTime, Day>();
		data.days.Add(DateTime.Today, new Day() { morning_low = "24", daytime_high = "29" });
		
		var result_content = new ResultContent();
		result_content.data = data;
		
		var root = new ResultContentRoot();
		root.result_content = result_content;
		
        var s = JsonConvert.SerializeObject(root);
	}

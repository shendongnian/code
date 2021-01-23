	void Main()
	{
		string json = @"{
							'symbol':'XX',
							'column_names':['Date','Open','High','Low','Close','Volume'],
							'data':[
								['2014-01-02',25.78,25.82,25.47,25.79,31843697.0],
								['2013-12-31',25.81,26.04,25.77,25.96,22809682.0]
									]
						}";
	
		DailyData dd = JsonConvert.DeserializeObject<DailyData>(json);
		dd.Dump();
	}
	
	class OneDayJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
	
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			OneDay obj = new OneDay();
			obj.date = reader.ReadAsDateTime() ?? DateTime.MinValue;
			obj.open = (double)(reader.ReadAsDecimal() ?? 0);
			obj.high = (double)(reader.ReadAsDecimal()?? 0);
			obj.low = (double)(reader.ReadAsDecimal() ?? 0);
			obj.close = (double)(reader.ReadAsDecimal() ?? 0);
			obj.volume = (double)(reader.ReadAsDecimal() ?? 0);
			reader.Read(); 
			return obj;
		}
	
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
	
	public class DailyData
	{
		public string symbol { get; set; }
		public List<OneDay> data { get; set; }
	}
	
	[JsonConverter(typeof(OneDayJsonConverter))]
	public class OneDay
	{
		public DateTime date { get; set; }
		public double open { get; set; }
		public double high { get; set; }
		public double low { get; set; }
		public double close { get; set; }
		public double volume { get; set; }
	}

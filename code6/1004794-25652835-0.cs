	public class CustomConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			...
			if(value is DateTime) {
				var d = value as DateTime;
				serializer.Serialize(writer, d);
			} 
			else {
				serializer.Serialize(writer, value);
			}
			
			...
		}
		
		// other overrides
	}

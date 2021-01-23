    	public class AConverter : JsonConverter
	{
		
		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(A));
		}
		
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			JToken jToken = JToken.FromObject(value);
			JObject jObject = (JObject)jToken;
			A aInfo = (A) value;
			string statusString = aInfo.Status == null ? string.Empty : SomeUtil.GetStateString((State)aInfo.Status.State, aInfo.Status.Downloading);
			jObject.AddFirst(new JProperty("MachineState", statusString));
			if (aInfo.UploadTime == DateTime.MinValue) {
				jObject.Remove("UploadTime");
				jObject.Add(new JProperty("UploadTime", null));
			}
			jObject.WriteTo(writer);
		}
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException("It's OK!");
		}
		
	}

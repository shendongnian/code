    public class ObjectToArrayConverter<T> : CustomCreationConverter<List<T>> where T : new()
	{
		public override List<T> Create(Type objectType)
		{
			return new List<T>();
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var target = new List<T>();
			try
			{
				// Load JObject from stream
				var jArray = JArray.Load(reader);
				// Populate the object properties
				serializer.Populate(jArray.CreateReader(), target);
			}
			catch (JsonReaderException)
			{
				// Handle case when object is not an array...
				// Load JObject from stream
				var jObject = JObject.Load(reader);
				// Create target object based on JObject
				var t = new T();
				// Populate the object properties
				serializer.Populate(jObject.CreateReader(), t);
				target.Add(t);
			}
			return target;
		}
	}

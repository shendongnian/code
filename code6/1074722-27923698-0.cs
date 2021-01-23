	[JsonConverter(typeof(SuppressModelValidationJsonConverter))]
	public sealed class SuppressModelValidation<TValue>
	{
		private readonly TValue _value;
		public SuppressModelValidation(TValue value)
		{
			this._value = value;
		}
		// this must be a method, not a property, or otherwise WebApi will validate
		public TValue GetValue()
		{
			return this._value;
		}
	}
	internal sealed class SuppressModelValidationJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
            // GetGenericArguments(Type) from http://www.codeducky.org/10-utilities-c-developers-should-know-part-two/
			return objectType.GetGenericArguments(typeof(SuppressModelValidation<>)).Length > 0;
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var valueType = objectType.GetGenericArguments(typeof(SuppressModelValidation<>)).Single();
			var value = serializer.Deserialize(reader, valueType);
			return value != null ? Activator.CreateInstance(objectType, value) : null;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}

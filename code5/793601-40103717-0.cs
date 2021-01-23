    /// <summary>
	/// Implements a <see cref="JsonStringBoolConverter"/> that will handle serialization of Json Boolean values to strings
	///  with capital letter.
	/// </summary>
	/// <summary>
	/// Starting from Newtonsoft.Json v9.0.1 default converting logic has been changed
	/// Old logic: 
	/// json boolean 'true' => .NET string "True"
	/// 
	/// New logic:
	/// json boolean 'true' => .NET string "true"
	/// 
	/// Details: https://github.com/JamesNK/Newtonsoft.Json/issues/1019
	/// </summary>
	public sealed class JsonBooleanStringConverter : JsonConverter
	{
		/// <summary>
		/// See <see cref="JsonConverter.CanConvert"/>.
		/// </summary>
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(string);
		}
		/// <summary>
		/// Specifies that this converter will not participate in writting.
		/// </summary>
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}
		/// <summary>
		/// See <see cref="JsonConverter.ReadJson"/>. 
		/// </summary>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JToken token = JToken.Load(reader);
			string str = token.Value<string>();
			if (token.Type == JTokenType.Boolean)
			{
				if (string.Equals("true", str, StringComparison.OrdinalIgnoreCase))
				{
					str = "True";
				}
				else if (string.Equals("false", str, StringComparison.OrdinalIgnoreCase))
				{
					str = "False";
				}
			}
			return str;
		}
		/// <summary>
		/// See <see cref="JsonConverter.WriteJson"/>.
		/// </summary>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}

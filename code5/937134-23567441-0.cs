    class MyItemConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(ItemToSell).IsAssignableFrom(objectType);
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject obj = JObject.Load(reader);
			string discriminator = (string)obj["ObjectType"];
			ItemToSell item;
			switch (discriminator)
			{
				case "apple":
					item = new Apple();
					break;
				case "books":
					item = new Books();
					break;
				case "melon":
					item = new Melon();
					break;
				default:
					throw new NotImplementedException();
			}
			serializer.Populate(obj.CreateReader(), item);
			return item;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
		}
	}

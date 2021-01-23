    class PersonListConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = serializer.Deserialize<JObject>(reader);
			var result = new PersonList();
			result.Persons = new List<Person>();
			
			foreach (var prop in jo.Properties())
			{
				var p = prop.Value.ToObject<Person>();
				// set name from property name
				p.Name = prop.Name;
				result.Persons.Add(p);
			}
			
			return result;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PersonList);
        }
    }

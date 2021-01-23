    public class CustomNestGeoShapeConverter : CustomCreationConverter<Nest.GeoShape>
	{
		public override Nest.GeoShape Create(Type objectType)
		{
			return null;
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JToken token = JToken.Load(reader);
			if(token == null) return null;
			switch (token["type"].ToString())
			{
				case "point":
					{
						var coords = new List<double>();
						coords.Add(Double.Parse(token["coordinates"][0].ToString()));
						coords.Add(Double.Parse(token["coordinates"][1].ToString()));
						return new Nest.PointGeoShape() { Coordinates = coords };
					}
			}
			return null;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}

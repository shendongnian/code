    public class DbGeometryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(string));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject location = JObject.Load(reader);
            JToken token = location["Geometry"]["WellKnownText"];
            string value = token.ToString();
            JToken sridToken = location["Geometry"]["CoordinateSystemId"];
            int srid;
            if (int.TryParse(sridToken.ToString(), out srid) == false)
            {
                //Set default coordinate system here.
                srid = 0;
            }
            DbGeometry converted;
            if (srid > 0)
                converted = DbGeometry.FromText(value, srid);
            else
                converted = DbGeometry.FromText(value);
            return converted;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Base serialization is fine
            serializer.Serialize(writer, value);
        }
    }
    public class DbGeographyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(string));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject location = JObject.Load(reader);
            JToken token = location["Geometry"]["WellKnownText"];
            string value = token.ToString();
            JToken sridToken = location["Geometry"]["CoordinateSystemId"];
            int srid;
            if (int.TryParse(sridToken.ToString(), out srid) == false)
            {
                //Set default coordinate system here.
                //NOTE: Geography should always have an SRID, and it has to match the data in the database else all comparisons will return NULL!
                srid = 0;
            }
            DbGeography converted;
            if (srid > 0)
                converted = DbGeography.FromText(value, srid);
            else
                converted = DbGeography.FromText(value);
            return converted;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Base serialization is fine
            serializer.Serialize(writer, value);
        }
    }

      public class DbGeographyConverter : JsonConverter
    {
        public override bool CanConvert ( Type objectType )
        {
            return objectType.IsAssignableFrom( typeof( DbGeography ) );
        }
        public override object ReadJson ( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            if ( reader.Value == null ) {
                return null;
            }
            return Parser.ToDbGeography( reader.Value.ToString() );
        }
        public override bool CanWrite { get { return true; } }
        public override void WriteJson ( JsonWriter writer, object value, JsonSerializer serializer )
        {
            //Attempting to serialize null dosent go well
            if ( value != null ) {
                var location = value as DbGeography;
                serializer.Serialize( writer, location.Latitude + "," + location.Longitude );
            }
        }
    }

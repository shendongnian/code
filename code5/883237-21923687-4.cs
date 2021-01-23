    public class RectangleConverter : JsonConverter
    {
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            var rectangle = (Rectangle)value;
            var jObject = GetObject( rectangle );
            jObject.WriteTo( writer );
        }
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            var jObject = JObject.Load( reader );
            return GetRectangle( jObject );
        }
        public override bool CanConvert( Type objectType )
        {
            throw new NotImplementedException();
        }
        protected static JObject GetObject( Rectangle rectangle )
        {
            var x = rectangle.X;
            var y = rectangle.Y;
            var width = rectangle.Width;
            var height = rectangle.Height;
            return JObject.FromObject( new { x, y, width, height } );
        }
        protected static Rectangle GetRectangle( JObject jObject )
        {
            var x = GetTokenValue( jObject, "x" ) ?? 0;
            var y = GetTokenValue( jObject, "y" ) ?? 0;
            var width = GetTokenValue( jObject, "width" ) ?? 0;
            var height = GetTokenValue( jObject, "height" ) ?? 0;
            return new Rectangle( x, y, width, height );
        }
        protected static Rectangle GetRectangle( JToken jToken )
        {
            var jObject = JObject.FromObject( jToken );
            return GetRectangle( jObject );
        }
        protected static int? GetTokenValue( JObject jObject, string tokenName )
        {
            JToken jToken;
            return jObject.TryGetValue( tokenName, StringComparison.InvariantCultureIgnoreCase, out jToken ) ? (int)jToken : (int?)null;
        }
    }

    public class RectangleListConverter : RectangleConverter
    {
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            var rectangleList = (IList<Rectangle>)value;
            var jArray = new JArray();
            foreach ( var rectangle in rectangleList )
            {
                jArray.Add( GetObject( rectangle ) );
            }
            jArray.WriteTo( writer );
        }
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            var rectangleList = new List<Rectangle>();
            var jArray = JArray.Load( reader );
            foreach ( var jToken in jArray )
            {
                rectangleList.Add( GetRectangle( jToken ) );
            }
            return rectangleList;
        }
        public override bool CanConvert( Type objectType )
        {
            throw new NotImplementedException();
        }
    }

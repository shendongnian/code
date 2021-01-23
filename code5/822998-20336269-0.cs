    JsConfig<MyPosition>.SerializeFn = position => position.ToString(null, CultureInfo.InvariantCulture);
    JsConfig<MyPosition>.DeSerializeFn = position => Position.Parse(position, CultureInfo.InvariantCulture);
---
    public class MyPosition
    {
        public Latitude Latitude { get; set; }
        public Longitude Longitude { get; set; }
        public override string ToString()
        {
            return ToString(null, CultureInfo.CurrentCulture);
        }
        public string ToString(CultureInfo culture)
        {
            return ToString(null, culture);
        }
        public string ToString(string format, CultureInfo culture)
        {
            var pos = new Position(Latitude, Longitude);
            return pos.ToString(null, culture);
        }
        public static implicit operator MyPosition(Position toConvert)
        {
            return new MyPosition
            {
                Latitude = toConvert.Latitude,
                Longitude = toConvert.Longitude
            };
        }
        public static implicit operator Position(MyPosition toConvert)
        {
            return new Position(toConvert.Latitude, toConvert.Longitude);
        }
    }

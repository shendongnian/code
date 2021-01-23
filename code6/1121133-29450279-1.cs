    public class User
    {
        //some other fields...
        [JsonConverter(typeof(JsonSingleOrEmptyArrayConverter<Personal>))]
        public Personal personal { get; set; }
        //some other fields...
    }

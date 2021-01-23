    var obj = JsonConvert.DeserializeObject<RootObject>(json);
    public class Ad
    {
        public string Type { get; set; }
        public string IdAd { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }
    public class Position
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Imei { get; set; }
    }
    public class RootObject
    {
        public Ad Ad { get; set; }
        public Position Position { get; set; }
    }

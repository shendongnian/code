    class Bookmark
    {
        public string title;
        public long id;
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime dateAdded;
        [JsonConverter(typeof(MicrosecondEpochConverter))]
        public DateTime lastModified;
        public string type;
        public string root;
        public long parent;
        public List<Bookmark> children;
        public string uri;
        public override string ToString()
        {
            return string.Format("{0} - {1}", title, uri);
        }
    }
    public class MicrosecondEpochConverter : DateTimeConverterBase
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds + "000");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return _epoch.AddMilliseconds((long)reader.Value / 1000d);
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var jsonString = File.ReadAllText(@"T:/bookmarks-2013-11-13.json");
            var rootMark = JsonConvert.DeserializeObject<Bookmark>(jsonString);
            var ret = JsonConvert.SerializeObject(rootMark);
        }
    }

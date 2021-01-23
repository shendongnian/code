    public class VersionConverter : JsonConverter 
    {
        private static Version ParseVersion(object versionObj)
        {
            var pattern = new Regex(@"^[\d.]+");
            var versionString = versionObj.ToString();
            if (!pattern.IsMatch(versionString)) 
                return null;
            var match = pattern.Match(versionString);
            versionString = match.Groups[0].ToString();
            Version version;
            Version.TryParse(versionString, out version);
            return version;
        }
        public override bool CanConvert(Type objectType)
        {
            return  objectType == typeof(System.Version);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            return ParseVersion((string)token);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var version = (Version)value;
            if (version != null)
                writer.WriteValue(value.ToString());
        }
    }

        public static dynamic[] Deserialize(Type headerType, Type bodyType, string json)
        {
            var root = Newtonsoft.Json.Linq.JObject.Parse(json);
            var serializer = new Newtonsoft.Json.JsonSerializer();
            dynamic header = serializer.Deserialize(root["Header"].CreateReader(),headerType);
            dynamic body = serializer.Deserialize(root["Body"].CreateReader(), bodyType);
            return new dynamic[] { header, body };
        }

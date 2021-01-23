    public class JsonDotNetSerializer
    {
        private JsonSerializerSettings settings;
        public static JsonDotNetSerializer RegisterNew(IAppHost appHost, JsonSerializerSettings settings = null)
        {
            var obj = new JsonDotNetSerializer(settings);
            
            appHost.ContentTypes.Register(
                "application/json",
                obj.WriteObjectToStream,
                obj.ReadObjectFromStream);
            return obj;
        }
        public JsonDotNetSerializer(JsonSerializerSettings settings)
        {
            this.settings = settings;
        }
        public void WriteObjectToStream(ServiceStack.Web.IRequest request, object response, Stream target)
        {
            var s = JsonConvert.SerializeObject(response, Formatting.None, this.settings);
            using (var writer = new StreamWriter(target, Encoding.UTF8, 1024, true))
            {
                writer.Write(s);
            }
        }
        public object ReadObjectFromStream(Type type, Stream source)
        {
            using (var reader = new StreamReader(source, Encoding.UTF8))
            {
                var s = reader.ReadToEnd();
                var o = JsonConvert.DeserializeObject(s, type, this.settings);
                return o;
            }
        }
    }

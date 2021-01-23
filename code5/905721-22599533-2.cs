    public class UseJsonDotNet : IPlugin
    {
        public JsonSerializerSettings Settings { get; set; }
        public void Register(IAppHost appHost)
        {
            appHost.ContentTypes.Register(
                "application/json",
                WriteObjectToStream,
                ReadObjectFromStream);
        }
        public void WriteObjectToStream(
            IRequest request, object response, Stream target)
        {
            var s = JsonConvert.SerializeObject(response, Formatting.None, Settings);
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
                var o = JsonConvert.DeserializeObject(s, type, Settings);
                return o;
            }
        }
    }

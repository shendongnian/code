    public class JsonDotNetFormatter : MediaTypeFormatter
    {
        public JsonDotNetFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }
        public override bool CanReadType(Type type)
        {
            return true;
        }
        public override bool CanWriteType(Type type)
        {
            return true;
        }
        public override async Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            using (var reader = new StreamReader(readStream))
            {
                return JsonConvert.DeserializeObject(await reader.ReadToEndAsync(), type);
            }
        }
        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            if (value == null) return;
            using (var writer = new StreamWriter(writeStream))
            {
                await writer.WriteAsync(JsonConvert.SerializeObject(value, new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
            }
        }

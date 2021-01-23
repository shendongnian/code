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
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var task = Task<object>.Factory.StartNew(() =>
            {
                using (var reader = new StreamReader(readStream))
                {
                    var s = reader.ReadToEnd();
                    try
                    {
                        return JsonConvert.DeserializeObject(s, type);
                    }
                    catch (JsonReaderException je)
                    {
                        throw;
                    }
                }
            });
            return task;
        }
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            if (value == null)
            {
                return Task.FromResult(0);
            }
            var task = Task.Factory.StartNew(() =>
            {
                using (var writer = new StreamWriter(writeStream))
                {
                    writer.Write(JsonConvert.SerializeObject(value, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                }
            });
            return task;
        }
    }

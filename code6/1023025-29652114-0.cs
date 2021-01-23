    public class CustomXmlMediaTypeFormatter : XmlMediaTypeFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomXmlMediaTypeFormatter"/> class.
        /// This XmlMediaTypeFormatter will ignore the doctype while reading the provided stream.
        /// </summary>
        public CustomXmlMediaTypeFormatter()
        {
            UseXmlSerializer = true;
        }
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (readStream == null)
                throw new ArgumentNullException("readStream");
            try
            {
                return Task.FromResult(ReadFromStream(type, readStream, content, formatterLogger));
            }
            catch (Exception ex)
            {
                var completionSource = new TaskCompletionSource<object>();
                completionSource.SetException(ex);
                return completionSource.Task;
            }
        }
        private object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var httpContentHeaders = content == null ? (HttpContentHeaders)null : content.Headers;
            if (httpContentHeaders != null)
            {
                var contentLength = httpContentHeaders.ContentLength;
                if ((contentLength.GetValueOrDefault() != 0L ? 0 : (contentLength.HasValue ? 1 : 0)) != 0)
                    return GetDefaultValueForType(type);
            }
            var settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Ignore
            };
            var deserializer = GetDeserializer(type, content);
            try
            {
                // The standard XmlMediaTypeFormatter will get the encoding from the HttpContent, instead
                // here the XmlReader will decide by itself according to the content
                using (var xmlReader = XmlReader.Create(readStream, settings))
                {
                    var xmlSerializer = deserializer as XmlSerializer;
                    if (xmlSerializer != null)
                        return xmlSerializer.Deserialize(xmlReader);
                    var objectSerializer = deserializer as XmlObjectSerializer;
                    if (objectSerializer == null)
                        throw new InvalidOperationException("xml object deserializer not available");
                    return objectSerializer.ReadObject(xmlReader);
                }
            }
            catch (Exception ex)
            {
                if (formatterLogger == null)
                {
                    throw;
                }
                formatterLogger.LogError(string.Empty, ex);
                return GetDefaultValueForType(type);
            }
        }
    }

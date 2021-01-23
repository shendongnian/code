    public class CustomJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public override async Task WriteToStreamAsync(
               Type type, object value, Stream writeStream, HttpContent content,
               TransportContext transportContext, CancellationToken cancellationToken)
        {
            if (type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(IAsyncEnumerator<>))
            {
                var writer = new JsonTextWriter(new StreamWriter(writeStream))
                             { CloseOutput = false };
                writer.WriteStartArray();
                await Serialize((dynamic)value, writer);
                writer.WriteEndArray();
                writer.Flush();
            }
            else
                await base.WriteToStreamAsync(type, value, writeStream, content,
                                              transportContext, cancellationToken);
        }
        async Task Serialize<T>(IAsyncEnumerator<StreamResult<T>> enumerator,
                                JsonTextWriter writer)
        {
            var serializer = JsonSerializer.Create(SerializerSettings);
            while (await enumerator.MoveNextAsync())
                serializer.Serialize(writer, enumerator.Current.Document);
        }
    }

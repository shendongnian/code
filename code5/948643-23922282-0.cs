    public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
    {
        if ((typeof(IEnumerable<AttributeCollection>).IsAssignableFrom(type)))
        {
            var list = (IEnumerable<AttributeCollection>)value;
            byte[] headerBytes = Encoding.UTF8.GetBytes("{\"allAttributes\":");
            byte[] footerBytes = Encoding.UTF8.GetBytes("}");
            writeStream.Write(headerBytes, 0, headerBytes.Length);
            foreach (var item in list)
            {
                await base.WriteToStreamAsync(item.GetType(), item, writeStream, content, transportContext);
            }
            writeStream.Write(footerBytes, 0, footerBytes.Length);
        }
        else
        {
            return await base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
        }
    }

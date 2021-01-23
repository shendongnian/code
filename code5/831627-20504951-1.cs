      public class JsonContent : HttpContent
        {
    
            private readonly MemoryStream _Stream = new MemoryStream();
    
            public JsonContent(object value)
            {
    
                var jw = new JsonTextWriter(new StreamWriter(_Stream)) {Formatting = Formatting.Indented};
                var serializer = new JsonSerializer();
                serializer.Serialize(jw, value);
                jw.Flush();
                _Stream.Position = 0;
    
            }
            protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                _Stream.CopyTo(stream);
                var tcs = new TaskCompletionSource<object>();
                tcs.SetResult(null);
                return tcs.Task;
            }
    
            protected override bool TryComputeLength(out long length)
            {
                length = _Stream.Length;
                return true;
            }
        }

    public class CsvContent<T> : HttpContent
        {
            private readonly MemoryStream _stream = new MemoryStream();
            public CsvContent(CsvFileDescription outputFileDescription, string filename, IEnumerable<T> data)
            {
                var cc = new CsvContext();
                var writer = new StreamWriter(_stream);
                cc.Write(data, writer, outputFileDescription);
                writer.Flush();
                _stream.Position = 0;
                
                Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                Headers.ContentDisposition.FileName = filename;
      
            }
            protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                return _stream.CopyToAsync(stream);
            }
    
            protected override bool TryComputeLength(out long length)
            {
                length = _stream.Length;
                return true;
            }
        }

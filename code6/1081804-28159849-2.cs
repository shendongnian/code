    public class GZipRequestDecompressingModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) =>
            {
                var request = (sender as HttpApplication).Request;
    
                string contentEncoding = request.Headers["Content-Encoding"];
    
                if (string.Equals(contentEncoding, "gzip",
                    StringComparison.OrdinalIgnoreCase))
                {
                    request.Filter = new GZipStream(request.Filter,
                        CompressionMode.Decompress);
                    request.Headers.Remove("Content-Encoding");
                }
            };
        }
        public void Dispose()
        {
        }
    }

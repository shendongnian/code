     public class ReusableContent : HttpContent
        {
            private readonly HttpContent _innerContent;
    
            public ReusableContent(HttpContent innerContent)
            {
                _innerContent = innerContent;
            }
    
            protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                await _innerContent.CopyToAsync(stream);
            }
    
            protected override bool TryComputeLength(out long length)
            {
                length = -1;
                return false;
            }
    
            protected override void Dispose(bool disposing)
            {
                // Don't call base dispose
                //base.Dispose(disposing);
            }
        }

    public class Base64MultiPartFileStreamProvider : MultipartFormDataStreamProvider
    {
        public Base64MultiPartFileStreamProvider(string path) : base(path)
        {
        }
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
           var stream = base.GetStream(parent, headers);
          ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
          if (contentDisposition != null)
          {
              if (!string.IsNullOrEmpty(contentDisposition.FileName))
              {
                  stream = new CryptoStream(stream, new FromBase64Transform(), CryptoStreamMode.Write);
              }
          }
          return stream;
        }
    }

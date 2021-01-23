    using System.Net.Http;
    using System.Net.Http.Headers;
    
    ...
    public class CustomMultipartFormDataStreamProvider 
        : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) 
            : base(path)
        {
        }
    
        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
        }
    }

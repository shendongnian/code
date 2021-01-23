    public class MultipartFormDataMemoryStreamProvider : MultipartStreamProvider
       {
          public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
          {
             return new MemoryStream();
          }
       }

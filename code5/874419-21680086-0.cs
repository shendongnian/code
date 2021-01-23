    public class FakeDownloadController: ApiController
    {
        public HttpResponseMessage Get([FromUri] int size)
                {
                    var result = new HttpResponseMessage(HttpStatusCode.OK);
                    byte[] data = new byte[size];
                    var stream = new MemoryStream(data);
                    result.Content = new StreamContent(stream);
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/binary");
                    var contentDisposition = new ContentDispositionHeaderValue("attachment");
                    contentDisposition.FileName = string.Format("{0}.{1}", "dummy","bin");
                    result.Content.Headers.ContentDisposition = contentDisposition;
                    return result;
                }
    }

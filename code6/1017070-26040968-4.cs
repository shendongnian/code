    [HttpGet]
    public HttpResponseMessage Test()
    {
        var path = System.Web.HttpContext.Current.Server.MapPath("~/Content/test.docx");;
        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        var stream = new FileStream(path, FileMode.Open);
        result.Content = new StreamContent(stream);
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        result.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        result.Content.Headers.ContentLength = stream.Length;
        return result;          
    }

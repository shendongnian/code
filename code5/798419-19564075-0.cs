    var result = new HttpResponseMessage(HttpStatusCode.OK)
                 {
                     Content = new ByteArrayContent(content)
                 };
    
    //a text file is actually an octet-stream (pdf, etc)
    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    //we used attachment to force download
    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                               {
                                                   FileName = "tets.txt"
                                               };

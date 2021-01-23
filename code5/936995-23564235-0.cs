    var result = Request.CreateResponse(HttpStatusCode.OK);
    result.Content = new ByteArrayContent(requestFile.FileContent);
    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = requestFile.FileName
                };
    return result;

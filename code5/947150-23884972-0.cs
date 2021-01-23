    public HttpResponseMessage ReturnBytes(byte[] bytes)
    {
      HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
      result.Content = new ByteArrayContent(bytes);
      result.Content.Headers.ContentType = 
          new MediaTypeHeaderValue("application/octet-stream");
      return result;
    }

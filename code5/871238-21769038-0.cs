    public HttpResponseMessage Get(int IRN)
            {
                try
                {
                    Multimedia image = new Multimedia();
                    MemoryStream imageStream = image.GetMedia(IRN);
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(imageStream);
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    return response;
                }
                catch (Exception ex)
                {
                    return HandleError(ex);           
                }
                         
            }
    GetMedia function:
    
        .....
                    MemoryStream mediaStream = new MemoryStream();
        ...
        FileStream temp = resource["file"] as FileStream;
                                mediaStream.SetLength(temp.Length);
                                temp.Read(mediaStream.GetBuffer(), 0, (int)temp.Length);
        
                                temp.Close();
    ....
    
      return mediaStream;

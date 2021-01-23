    if (_PostData != null && _PostData > 0)
    {
       requestMessage.Content = new HttpBufferContent(request.PostData.AsBuffer());
       requestMessage.Content.Headers.Add(HeaderContentType, request.ContentType); 
    }

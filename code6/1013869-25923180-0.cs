    HttpResponseMessage response = ...
    HttpContent content = response.Content;
    if(content is MultipartContent)
    {
        // loop through parts
    }

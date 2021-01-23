    public async Task<HttpResponseMessage> PostFormData()
    {
        // Check if the request contains multipart/form-data.
        if (!Request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }
        string root = HttpContext.Current.Server.MapPath("~/App_Data");
        var provider = new MultipartFormDataStreamProvider(root);
        // Read the form data.
        await Request.Content.ReadAsMultipartAsync(provider);
        //use provider.FileData to get the file
        //use provider.FormData to get FeedItemParams. you have to deserialize the JSON yourself
        return Request.CreateResponse(HttpStatusCode.OK);
    }

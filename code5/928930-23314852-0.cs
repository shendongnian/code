    // Check if the request contains multipart/form-data.
    if (!Request.Content.IsMimeMultipartContent())
    {
      throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
    }
    string root = HttpContext.Current.Server.MapPath("~/App_Data");
    var provider = new MultipartFormDataStreamProvider(root);
    try
    {
      // Read the form data.
      await Request.Content.ReadAsMultipartAsync(provider);
      // TODO ... process files
      return Request.CreateResponse(HttpStatusCode.OK);
    }
    catch (System.Exception e)
    {
      return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
    }

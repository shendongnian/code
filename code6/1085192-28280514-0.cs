    var response = new System.Net.Http.HttpResponseMessage();
    if (context.Exception is System.IO.FileNotFoundException) 
    {
        response.StatusCode = HttpStatusCode.NotFound;
    }
    else if (context.Exception is IOException) 
    {
        response.StatusCode = HttpStatusCode.InternalServerError;
    }

    if (context.Exception is System.IO.FileNotFoundException)) {
      response.StatusCode = HttpStatusCode.NotFound;
    } else if (context.Exception is Exception) {
      response.StatusCode = HttpStatusCode.InternalServerError;
    }

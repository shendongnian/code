    switch (context.Exception.GetType().FullName) {
      case "System.IO.FileNotFoundException":
        response.StatusCode = HttpStatusCode.NotFound;
        break;
      case "Exception":
        response.StatusCode = HttpStatusCode.InternalServerError;
        break;
    }

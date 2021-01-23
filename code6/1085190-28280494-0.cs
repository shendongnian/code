    var response = new System.Net.Http.HttpResponseMessage();
    //switch on the exception type
    if (context.Exception is System.IO.FileNotFoundException) {
        response.StatusCode = HttpStatusCode.NotFound;
    }
    else if (context.Exception is Exception) {
        response.StatusCode = HttpStatusCode.InternalServerError;
    }
    else {
        // you'll likely want a default case to make sure you catch everything
    }

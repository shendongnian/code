    HttpException httpException = exception as HttpException
        ?? new HttpException(500, "Internal Server Error", exception);
    Response.Clear();
    Server.ClearError();
    var routeData = new RouteData();
    routeData.Values.Add("Controller", "Error");
    routeData.Values.Add("fromAppErrorEvent", true);
    int exceptionType = httpException.GetHttpCode();

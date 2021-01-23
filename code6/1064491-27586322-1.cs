    var code = (exception is HttpException) ? (exception as HttpException).GetHttpCode() : 500;
    var headers = Request.Headers;
    headers.Add(new NameValueCollection
    {
        {"ErrorUrl", Context.Request.RawUrl},
        {"ErrorCode", code.ToString()}
    });
    Context.Server.TransferRequest("~/error", false, null, headers, true);

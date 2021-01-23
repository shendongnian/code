    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void IsFacebookPageLiked()
    {
        SimpleMessage message = new SimpleMessage() {Message = "Hello World"};
        string json = JsonConvert.Serialize(message);
        HttpContext.Current.Response.ContentType = "application/json; charset=utf-8";
        HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");
        HttpContext.Current.Response.Write(json);
    }

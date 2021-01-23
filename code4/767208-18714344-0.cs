    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "/GetImage", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
    public Stream GetImage()
    {
        var m = new MemoryStream();
        //Fill m
        WebOperationContext.Current.OutgoingResponse.ContentType = "image/png";
        WebOperationContext.Current.OutgoingResponse.ContentLength = m.Length;
        return m;
    }
 

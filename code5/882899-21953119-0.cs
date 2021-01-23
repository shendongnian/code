    [ServiceContract]
    public interface IMyWebSvc
    {
        
        [OperationContract]
        [WebGet(UriTemplate = "/api/{something}/{id}",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        MyWebSvcRetObj GetData(string something, string id);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/api/{something}/{id}",
            RequestFormat = WebMessageFormat.Json,    
            BodyStyle = WebMessageBodyStyle.Bare)]
        string Update(MoreData IncomingData, string something, string id);       
    }

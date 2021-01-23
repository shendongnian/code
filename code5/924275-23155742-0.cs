    [OperationContract]
    [WebGet(UriTemplate = "GetData/{value}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
            string GetData2(string value);
    
    [OperationContract]
    [WebInvoke(UriTemplate = "GetData/{value}", RequestFormat=WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Xml)]
            string GetData(string value);

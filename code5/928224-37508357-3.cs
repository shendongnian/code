    [ServiceContract(Namespace="http://service.stackoverflow.com")]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
          UriTemplate = "GetData",
            RequestFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetData([MessageParameter(Name="Bar")] DataRequest xml1, string xml2);
    }

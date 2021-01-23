    [ServiceContract]
    public interface IServiceContract
    {
       [OperationContract]
       [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json)]
           List<Site> getuserSite(String UserCode);
    }

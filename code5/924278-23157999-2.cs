    [ServiceContract]
    public interface IWeChatBOService
    {
        [WebGet(UriTemplate = "WeChatService/{msgBody}")]
        [OperationContract]
        string ProcessRequest(string msgBody);
        [WebInvoke(Method = "POST", UriTemplate = "WeChatService")]
        [OperationContract]
        string ProcessRequest2(string msgBody);
    }

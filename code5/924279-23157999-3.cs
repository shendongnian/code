    [ServiceContract]
    public interface IWeChatBOService
    {
        [WebGet(UriTemplate = "messages/{messageId}")]
        [OperationContract]
        string GetMessage(string messageId);
        [WebInvoke(Method = "POST", UriTemplate = "messages")]
        [OperationContract]
        string InsertMessage(string message);
    }

    [ServiceContract]
    public interface IWeChatBOService
    {
        [WebGet(UriTemplate = "posts/{postId}")]
        [OperationContract]
        string GetPost(string postId);
        [WebInvoke(Method = "POST", UriTemplate = "posts")]
        [OperationContract]
        string InsertPost(string postBody);
    }

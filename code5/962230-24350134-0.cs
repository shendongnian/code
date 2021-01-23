    [ServiceContract]
    public interface IService
    {
        [WebGet(UriTemplate = "callback?code={requestCode}")]
        void OAuthCallback(string requestCode);
    }

        [ServiceContract]
        public interface RestServiceInterface
        {
           [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "MySVC")]
           Stream MySVC(string stringP); 
        }

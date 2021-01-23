    [ServiceContract]
    public interface IServiceJson {
    	[OperationContract]
    	[WebGet(UriTemplate = "Book/{id}", ResponseFormat=WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    	Book GetBookById(string id);
    }

    [ServiceContract]
    public interface IFruitFactory
    {
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetInvoices")]
        FileObject[] GetInvoices(string customerID, string invoiceFolder, string customerName, string[] orderNames);
    }

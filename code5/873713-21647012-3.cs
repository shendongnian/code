    // The callback interface is used to send messages from service back to client.
    // The Result operation will return the current result after each operation.
    public interface IDataExchangeCallback
    {
        [OperationContract(IsOneWay = true)]
        void Result(string result);
    }
<!-->

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);
    }

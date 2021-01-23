    [ServiceContract]
    public interface IProvider
    {
        [OperationContract]
        int MyApiCall_1(string param);
        [OperationContract]
        string MyApiCall_2(int number);
    }

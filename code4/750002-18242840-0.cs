    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        void Add(double value);
        [OperationContract]
        List<double> GetAllNumbers();
    }

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [Timing]   // Timing for this Operation!
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }

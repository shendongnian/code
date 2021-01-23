    [ServiceContract]
    public interface ISampleService
    {
      [OperationContract]
      [FaultContractAttribute(typeof(InvalidSessionException)]
      void SampleMethod();
    }

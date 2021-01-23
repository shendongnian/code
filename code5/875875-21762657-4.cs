    [ServiceContract]
    public interface ISampleService
    {
      [OperationContract]
      [FaultContractAttribute(typeof(InvalidSessionException)]
      void SampleMethod();
    }
    void SampleMethod()
    {
      ...
      throw new FaultException<InvalidSessionException>();
    }

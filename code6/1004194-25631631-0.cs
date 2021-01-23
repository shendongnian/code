    [ServiceContract]
    public interface IContent
    {
         [OperationContract]
         void DoSomething(SomeModel model);
    }

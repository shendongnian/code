    internal struct PrivateData { ... }
    internal interface IMyInterface
    {
        Result SomePrivateComputation(PrivateData data);
    }
    public class MyPublicClass : IMyInterface
    {
        Result IMyInterface.SomePrivateComputation(PrivateData data)
        {
            ...
        }
    }

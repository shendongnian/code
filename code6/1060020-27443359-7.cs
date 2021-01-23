    [ServiceContract(
        ......
        )
    ]
    [ExceptionMarshallingBehavior]
    [ServiceKnownType(typeof(.....))]
    [ServiceKnownType(typeof(.....))]
    public interface IMyWebService
    {
        [OperationContract]
        string GetVersion();
    
        ...
    }

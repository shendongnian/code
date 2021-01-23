    [ServiceContract(SessionMode = SessionMode.Required, ...)]
    [ServiceKnownType(typeof(MyBaseClass ))]
    [ServiceKnownType(typeof(MyDeliveredClass ))]
    public interface IMySerivceContract {
        ...
    }

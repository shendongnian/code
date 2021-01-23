    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        User AddUser(User user);
    }

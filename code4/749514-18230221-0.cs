    [ServiceContract]
    public interface INewUser
    {
        [OperationContract]
        UserInfo CreateNewUser(string userName);
    }

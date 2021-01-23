    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Login(string username, string password); // it returns URL of UserService or AdminService
    }

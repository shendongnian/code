    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        void DoUserStuff();
    }
    [ServiceContract]
    public interface IAdminService : IUserService
    {
        [OperationContract]
        void DoAdminStuff();
    }

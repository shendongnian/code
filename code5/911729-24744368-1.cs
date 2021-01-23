    [ServiceContract]
    public interface IDbRepository
    {
        [OperationContract]
        object Insert(object entity);
        [OperationContract]
        object Update(object entity);
    }

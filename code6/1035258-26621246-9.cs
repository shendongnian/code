    [ServiceContract]
    public interface IServiceXYZ   // NO GENERICS!! YOU BASE CLASS
    {
        [OperationContract]
        void Insert(BaseClass entity);
        [OperationContract]
        void Update(BaseClass entity);
        [OperationContract]
        void Delete(BaseClass entity);
    }

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Room GetRoom();
        [OperationContract]
        List<Department> GetDepartments();
    }

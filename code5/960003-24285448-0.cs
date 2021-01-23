    public interface IName
    {
        [OperationContract(IsOneWay=false)]
        string GetName();
    }

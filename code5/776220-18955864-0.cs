    [ServiceContract]
    [ServiceKnownType(typeof(List<string>))] // <== this will enable the serializer to send and receive List<string> objects
    public interface IProvider
    {
        [OperationContract]
        DataSet CreateDataSetFromSQL(string command, params object[] par);
    }

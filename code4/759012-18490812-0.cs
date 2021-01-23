    public interface ICommunicationService
    {
        [OperationContract]
        Row[] GetCrmData(string view, string pageNumber, string pageSize);
    }

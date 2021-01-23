    public interface ICommunicationService
    {
        [OperationContract]
        Row[] GetCrmData(string view, int pageNumber, int pageSize);
    }

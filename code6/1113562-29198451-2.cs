    [ServiceContract]
    public interface IEmailService
    {
        [OperationContract]
        void SendEmail(EmailDTO email);
    }

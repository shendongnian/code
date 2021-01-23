    [ServiceContract]
    public interface ISendMail
    {
        /// <summary />
        /// <param name="emailType">This parameter should be 'myEmailType'</param>
        [OperationContract]
        void Send(string senderEmail, MyEmailType emailType);
    }

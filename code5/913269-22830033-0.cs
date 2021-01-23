    [DataContract]
    public class Email
    {
        [DataMember]
        private string senderEmail;
        
        [DataMember]
        private MyEmailType emailType;
    
        public string SenderEmail { get { return senderEmail; } set { senderEmail = value; } }
        public MyEmailType EmailType { get { return emailType; } set { emailType = value; } }
    }

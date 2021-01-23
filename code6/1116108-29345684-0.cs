    public class MockSmtpClient : SmtpClient
    {
        public virtual void Send(MailMessage mailMessage)
        {
        }
    
        public virtual string Host
        {
            get { return "mocksmtpclient.local"; }
        }
    
        public virtual int Port
        {
            get { return 17; }
        }
    }

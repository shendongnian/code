    interface IMessageSender
    {
        string From { get; set; }
        string To { get; set; }
        string Message { get; set; }
    
        void Send();
    }
    
    abstract class MessageSenderWithSubjectBase : IMessageSender
    {
        string From { get; set; }
        string To { get; set; }
        string Message { get; set; }
    
        string Subject { get; set; }
    
        abstract void Send();
    }
    
    class EmailSender : MessageSenderWithSubjectBase
    {
        override void Send() { // send email }
    }
    
    class SmsSender : IMessageSender
    {
        override void Send() { // send sms }
    }

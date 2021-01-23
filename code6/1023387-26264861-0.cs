    class CustomeMessageFormatter : IMessageFormatter
    {
      
        #region IMessageFormatter Members
        public bool  CanRead(Message message)
        {
        throw new NotImplementedException();
        }
        public object  Read(Message message)
        {
        throw new NotImplementedException();
        }
        public void  Write(Message message, object obj)
        {
        PersonMessage person=null;
        if (obj is PersonMessage)
            person =(PersonMessage)obj;
        if (message == null)
                throw new ArgumentNullException("message");
 
            if (obj == null)
                throw new ArgumentNullException("obj");
            string Message = person.SimpleMessage;
            message.BodyStream = new MemoryStream(Encoding.UTF8.GetBytes(Message));
 
            //Need to reset the body type, in case the same message
            //is reused by some other formatter.
            message.BodyType = 0;
        }
        #endregion
        #region ICloneable Members
        public object  Clone()
        {
        throw new NotImplementedException();
        }
        #endregion
        }
    public class PersonMessage
    {
        public PersonMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Person Message");
            sb.Append("<?XML Version=\"1.0\">");
            sb.Append("<Person>");
            sb.Append("<Employee>");
            sb.Append("<Name>Manthan</Name>");
            sb.Append("</Employee>");
            sb.Append("</Person>");
            SimpleMessage = sb.ToString();
        }
        public string SimpleMessage { get; set; }
    }

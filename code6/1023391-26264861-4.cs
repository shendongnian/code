    class CustomeMessageFormatter : IMessageFormatter
    {
        #region IMessageFormatter Members
        public bool CanRead(Message message)
        {
            throw new NotImplementedException();
        }
        public object Read(Message message)
        {
            throw new NotImplementedException();
        }
        public void Write(Message message, object obj)
        {
            
            if (message == null)
                throw new ArgumentNullException("message");
            if (obj == null)
                throw new ArgumentNullException("obj");
            string Message = (string)obj;
            message.BodyStream = new MemoryStream(Encoding.UTF8.GetBytes(Message));
            //Need to reset the body type, in case the same message
            //is reused by some other formatter.
            message.BodyType = 0;
        }
        #endregion
        #region ICloneable Members
        public object Clone()
        {
            return new CustomeMessageFormatter();
        }
        #endregion
    }

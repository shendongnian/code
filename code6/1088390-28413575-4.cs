        public class MessageRequest
    {
        private readonly string _messageId;
        private readonly Operation _operation;
        public MessageRequest(string id, Operation operation)
        {
            _messageId = id;
            _operation = operation;
        }
        public string MessageId { get { return _messageId; } }
        public Operation Operation { get { return _operation;  } }
    }
        public class MessageResponse
    {
        private object _data;
        public MessageRequest Request { get; set; }
        public T Data<T>()
        {
            return (T)Convert.ChangeType(_data, typeof(T));
        }
        public void SetData(object data)
        {
            _data = data;
        }
    }

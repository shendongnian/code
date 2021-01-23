    [Serializable]
    public class StorableException
    {
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public StorableException()
        {
            this.TimeStamp = DateTime.Now;
        }
        public StorableException(string Message) : this()
        {
            this.Message = Message;
        }
        public StorableException(System.Exception ex) : this(ex.Message)
        {
            this.StackTrace = ex.StackTrace;
        }
        public override string ToString()
        {
            return this.Message + this.StackTrace;
        }
    }

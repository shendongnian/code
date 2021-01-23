    public class IdNotProvidedException : Exception
    {
        public string MyCommandName { get; set; }
        public IdNotProvidedException(string msg)
            : base(msg)
        {
        }
        public IdNotProvidedException(string msg, string myCommandName)
            : base(msg)
        {
            this.MyCommandName = myCommandName;
        }
    }

    public class Status<TData>: Status where TData: class
    {
        public string SeverityCode { set; get; }
        public double ReturnCode { set; get; }
        public double ReasonCode { set; get; }
        public T Data { get { return (T)base.Data; } set { base.Data = value; }}
    }

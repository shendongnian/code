    public abstract class Status
    {
        public string SeverityCode { set; get; }
        public double ReturnCode { set; get; }
        public double ReasonCode { set; get; }
        protected object Data { get; set; }
    }
    public class Status<TData>: Status where TData: class
    {
        public new TData Data { get { return (TData)base.Data; } set { base.Data = value; } }
    }

    public abstract class Business
    {
        public BusinessType BusinessType { get; set; }
        public abstract IBusinessMapper GetMapper():
    }

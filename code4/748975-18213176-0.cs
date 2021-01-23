    public class Fluent<T>
        where T : Flow
    {
        public virtual IList<T> FlowCollection { get; set; }
        public virtual double InitialBaseflow { get; set; }
    }

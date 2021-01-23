    public class Fluent<T>
        where T : Flow
    {
        public IList<T> FlowCollection { get; set; }
        public double InitialBaseflow { get; set; }
    }

    public class SelectiveOutputRange<T> : Tuple<T, T>
    {
        public SelectiveOutputRange(T item1, T item2)
            : base(item1, item2)
        {
        }
    
        public SelectiveOutputRange() : base(default(T), default(T))
        {
        }
    
        public override string ToString()
        {
            return this.Item1 + " to " + this.Item2;
        }
    }

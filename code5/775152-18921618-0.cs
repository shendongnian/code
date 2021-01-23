    public class SelectiveOutputRange<T> : Tuple<T, T> {
        public SelectiveOutputRange() 
            : base(default(T), default(T))
        {
        }
        public override string ToString() {
            return this.Item1 + " to " + this.Item2;
        }
    }

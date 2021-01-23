    public class Sequence<T>: List<T>
    {
        public double Cost { get; set; }
        public override string ToString() // for the cache key
        {
            return string.Join("|", this.Select(t => t.ToString()));
        }
        public Sequence(IEnumerable<T> sequence)
        {
            this.AddRange(sequence);
            Cost = 0;
        }
    }
    public class Substitution<T>
    {
        public IEnumerable<T> OriginalSequence { get; set; }
        public IEnumerable<T> SwappedSequence { get; set; }
        public double Cost { get; set; }
    }

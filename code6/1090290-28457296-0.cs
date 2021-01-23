    public abstract class Range
    {
        public abstract bool FromGreaterTo { get; }
    }
    public class Range<T> : Range
    {
        // existing Range<T> code
    }

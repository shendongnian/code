    public class Range<TValue, TInfo>
    {
        private readonly IComparer<TValue> comparer;
        public Range(IComparer<TValue> comparer)
        {
            this.comparer = comparer;
        }
        public Range(IComparer<TValue> comparer)
            : this(Comparer<TValue>.Default)
        {
        }
        
        public TValue From { get; set; }
        public TValue To { get; set; }
        public TInfo Info { get; set; }
        public bool InRange(T value, bool inclusive = true)
        {
            var lowerBound = this.comparer.Compare(value, this.From);
            if (lowerBound < 0)
            {
                return false;
            }
            else if (!inclusive && lowerBound == 0)
            {
                return false;
            }
          
            var upperBound = this.comparer.Compare(value, this.To);
            if (upperBound > 0)
            {
                return false;
            }
            else if (!inclusive && upperBound == 0)
            {
                return false;
            }
            return true;
        }
    }

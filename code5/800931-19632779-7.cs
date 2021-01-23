    public class RangeSpecification : ISpecification<int>
    {
        private readonly int _from;
        private readonly int _to;
        public RangeSpecification(int from, int to)
        {
            _to = to;
            _from = from;
        }
        public bool IsSatisfiedBy(int value)
        {
            return _from <= value && value <= _to;
        }
    }

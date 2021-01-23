    public class InSpecification : ISpecification<int>
    {
        private readonly int[] _values;
        public InSpecification(params int[] values)
        {
            _values = values;
        }
        public bool IsSatisfiedBy(int value)
        {
            return _values.Contains(value);
        }
    }

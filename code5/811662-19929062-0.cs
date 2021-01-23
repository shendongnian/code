    public class Slot
    {
        private double _LowerBound;
        private double _UpperBound;
        private List<double> _Values;
        public Slot(double lowerBound, double upperBound)
        {
            if (upperBound < lowerBound)
                throw new ArgumentOutOfRangeException("The upper bound must be greater or equal the lower bound.");
            _LowerBound = lowerBound;
            _UpperBound = upperBound;
            _Values = new List<double>();
            _Values.Add(lowerBound);
            Values = _Values.AsReadOnly();
        }
        public ReadOnlyCollection<double> Values { get; private set; }
        public void Add(double value)
        {
            if (!IsResponsible(value))
            {
                var message = String.Format("The value {0} is not greater or equal {1} or less or equal {2}.", value, _LowerBound, _UpperBound);
                throw new ArgumentOutOfRangeException(message);
            }
            _Values.Add(value);
        }
        public bool IsResponsible(double value)
        {
            return value >= _LowerBound
                   && value <= _UpperBound;
        }
        public override string ToString()
        {
            return String.Format("Range: {0} - {1}, Elements: {2}", _LowerBound, _UpperBound, _Values.Count);
        }
    }

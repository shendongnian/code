    public class Combinator<T>
    {
        private readonly Dictionary<int, T> _Pattern;
        private readonly int _Min = 0;
        private readonly int _Max;
        private List<int> _CurrentCombination;
        public Combinator(IEnumerable<T> pattern)
        {
            _Pattern = new Dictionary<int, T>();
            for (int i = 0; i < pattern.Count(); i++)
            {
                _Pattern.Add(i, pattern.ElementAt(i));
            }
            _CurrentCombination = new List<int>();
            _Max = pattern.Count() - 1;
        }
        public bool HasFinised
        {
            get;
            private set;
        }
        public IEnumerable<T> Next()
        {
            // Initialize or increase.
            if (_CurrentCombination.Count == 0)
            {
                _CurrentCombination.Add(_Min);
            }
            else
            {
                MyIncrease(_CurrentCombination.Count - 1);
            }
            if (_CurrentCombination.Count - 1 == _Max && _CurrentCombination.All(Key => Key == _Max))
            {
                HasFinised = true;
            }
            return _CurrentCombination.Select(Key => _Pattern[Key]).ToList();;
        }
        private void MyIncrease(int index)
        {
            if (index >= 0)
            {
                _CurrentCombination[index] = _CurrentCombination[index] + 1;
                if (_CurrentCombination[index] > _Max)
                {
                    _CurrentCombination[index] = _Min;
                    if (index - 1 < 0)
                    {
                        _CurrentCombination.Insert(0, -1);
                        index++;
                    }
                    MyIncrease(index - 1);
                }
            }
        }
    }

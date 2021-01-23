    public class RandomHash
    {
        private readonly Dictionary<int, int> _mydictionary;
        private List<int> _usedNumbers;
        private readonly Random _rnd;
        private readonly int _size;
        public RandomHash(int size)
        {
            _mydictionary = new Dictionary<int, int>();
            _usedNumbers = new List<int>();
            _rnd = new Random(100); // magic seed
            _size = size;
        }
        public int HashNumber(int num)
        {
            if (_mydictionary.ContainsKey(num))
                return _mydictionary[num];
            int n = _rnd.Next(1, _size);
            while (n == num || _mydictionary.ContainsKey(n))
            {
                n = _rnd.Next(1, _size);
            }
            _mydictionary.Add(num, n);
            return n;
        }
    }

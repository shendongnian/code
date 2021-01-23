    public class ConcurrentStringGenerator
    {
        private readonly Random _random;
        private readonly string _charset;
        private readonly int _length;
        private readonly ConcurrentDictionary<string, byte> _numbers;
            
        public ConcurrentStringGenerator(string charset, int length)
        {
            _charset = charset;
            _length = length;
            _random = new Random();
            _numbers = new ConcurrentDictionary<string, byte>();
        }
    
        public string Reserve()
        {
            var str = Generate();
            while (!_numbers.TryAdd(str, 0))
            {
                str = Generate();
            }
            return str;
        }
    
        public bool Release(string str)
        {
            byte b;
            return _numbers.TryRemove(str, out b);
        }
    
        private string Generate()
        {
            return new string(Enumerable.Repeat(_charset, _length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }

    public class RandomNumberGenerator
    {
        private Random _rndNmbrs = new Random();
        // Generate's a single random value
        public int Generate()
        {
            return _rndNmbrs.Next();
        }
        // Generate's a list of random values
        public List<int> Generate(int count)
        {
            var ret = new List<int>();
            for (var i = 0; i < count; i++) 
            {
                ret.Add(_rndNmbrs.Next();
            }
            return ret;
        }
    }

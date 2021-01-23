    public class RandomNumberGenerator
    {
        private Random _rndNmbrs = new Random();
        // Generate's a single random value
        public int Generate(int min, int max)
        {
            return _rndNmbrs.Next(min, max);
        }
        // Generate's a list of random values
        public List<int> Generate(int count, int min, int max)
        {
            var ret = new List<int>();
            for (var i = 0; i < count; i++) 
            {
                ret.Add(_rndNmbrs.Next(min, max);
            }
            return ret;
        }
    }

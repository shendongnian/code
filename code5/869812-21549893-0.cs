    public static class RandomNumberGenerator
    {
        private static Random _randomNumberGenerator = new Random();
    
        // Generate's your random number
        public static int Generate()
        {
            return _rndNmbrs.Next();
        }
    }

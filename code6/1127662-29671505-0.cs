    static class RGen
    {
        private static Random seedGen = new Random();
        
        public static Random GetRGenerator()
        {
            lock (seedGen)
            {
                return new Random(seedGen.Next());
            }
        }
    }

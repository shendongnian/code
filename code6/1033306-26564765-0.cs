    class Exponential
    {
        public int base;
        public int power;
    }
    class ExponentialResult : List<Exponential>
    {
        private BigInteger result;
        
        public ExponentialResult(BigInteger value)
        {
            result = value;
        }
        public BigInteger Result
        {
            get { return result; }
        }
    }
    public BigIntegerComparer : IComparer
    {
        public int Compare(BigIntegerComparer x, BigIntegerComparer y)
        {
            return (int) BigInteger.Subtract(x, y);
        }
    }

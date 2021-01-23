    public static class StatusGoodExtensions
    {
        public static int OrderIndex(this StatusGood statusIn)
        {
            switch ( statusIn )
            {
                case StatusGood.Normal: return 0;
                case StatusGood.Aged: return 1;
                case StatusGood.Empty: return 2;
                case StatusGood.Dead: return 3;
            }
            throw new NotImplementedException(statusIn.ToString());
        }
    }

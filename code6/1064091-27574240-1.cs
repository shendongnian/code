    class MultiCounter
    {
        private int _counterMax;
        private byte[] _counters;
        public MultiCounter(int counterCount, int counterMax)
        {
            _counterMax = counterMax;
            _counters = new byte[counterCount];
        }
        public bool Increment()
        {
            for (int i = 0; i < _counters.Length; i++)
            {
                if (++_counters[i] < _counterMax)
                {
                    return true;
                }
                _counters[i] = 0;
            }
            return false;
        }
        public int this[int index] { get { return _counters[index]; } }
    }

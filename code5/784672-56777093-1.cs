    public class RandomEx : Random
    {
        private uint _boolBits;
        public RandomEx() : base() { }
        public RandomEx(int seed) : base(seed) { }
        public bool NextBoolean()
        {
            _boolBits >>= 1;
            if (_boolBits <= 1) _boolBits = (uint)~this.Next();
            return (_boolBits & 1) == 0;
        }
    }

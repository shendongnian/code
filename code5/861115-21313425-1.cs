    public struct iint
    {
        private readonly int _int;
        public iint(int value) 
        {
            if(value  == int.MaxValue || value == int.MinValue)
                throw new InvalidOperationException("min/max value reserved in iint");
            _int = value;
        }
        public static explicit operator int(iint @this)
        {
            if(@this._int == int.MaxValue || @this._int == int.MinValue)
                throw new InvalidOperationException("cannot implicit convert infinite iint to int");
            return @this._int;
        }
        public static implicit operator iint(int other)
        {
            if(other == int.MaxValue || other == int.MinValue)
                throw new InvalidOperationException("cannot implicit convert max-value into to iint");
            return new iint(other);
        }
        public bool IsPositiveInfinity {get { return _int == int.MaxValue; } }
        public bool IsNegativeInfinity { get { return _int == int.MinValue; } }
        private iint(bool positive)
        {
            if (positive)
                _int = int.MaxValue;
            else
                _int = int.MinValue;
        }
        public static readonly iint PositiveInfinity = new iint(true);
        public static readonly iint NegativeInfinity = new iint(false);
        public static bool operator ==(iint a, iint b)
        {
            return a._int == b._int;
        }
        public static bool operator !=(iint a, iint b)
        {
            return a._int != b._int;
        }
        public static iint operator +(iint a, iint b)
        {
            if (a.IsPositiveInfinity && b.IsNegativeInfinity)
                throw new InvalidOperationException();
            if (b.IsPositiveInfinity && a.IsNegativeInfinity)
                throw new InvalidOperationException();
            if (a.IsPositiveInfinity)
                return PositiveInfinity;
            if (a.IsNegativeInfinity)
                return NegativeInfinity;
            if (b.IsPositiveInfinity)
                return PositiveInfinity;
            if (b.IsNegativeInfinity)
                return NegativeInfinity;
            
            return a._int + b._int;
        }
        public static iint operator -(iint a, iint b)
        {
            if (a.IsPositiveInfinity && b.IsPositiveInfinity)
                throw new InvalidOperationException();
            if (a.IsNegativeInfinity && b.IsNegativeInfinity)
                throw new InvalidOperationException();
            if (a.IsPositiveInfinity)
                return PositiveInfinity;
            if (a.IsNegativeInfinity)
                return NegativeInfinity;
            if (b.IsPositiveInfinity)
                return NegativeInfinity;
            if (b.IsNegativeInfinity)
                return PositiveInfinity;
            return a._int - b._int;
        }
        public static iint operator -(iint a)
        {
            if (a.IsNegativeInfinity)
                return PositiveInfinity;
            if (a.IsPositiveInfinity)
                return NegativeInfinity;
            return -a;
        }
        /* etc... */
        /* other operators here */
    }

    struct Priority
    {
        public static readonly Priority High = new Priority('H');
        public static readonly Priority Medium = new Priority('M');
        public static readonly Priority Low = new Priority('L');
        static Priority()
        {
            register(High);
            register(Medium);
            register(Low);
        }
        public static bool TryGetPriority(char code, out Priority priority)
        {
            return _map.TryGetValue(code, out priority);
        }
        public static Priority GetPriority(char code)
        {
            Priority priority;
            if (!TryGetPriority(code, out priority))
                throw new ArgumentException("Code doesn't represent an existing priority.", "code");
            return priority;
        }
        public override int GetHashCode()
        {
            return _code.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Priority)) return false;
            return ((Priority)obj)._code == _code;
        }
        public override string ToString()
        {
            return _code.ToString();
        }
        public static implicit operator char(Priority @this) { return @this._code; }
        public static explicit operator Priority(char code)
        {
            Priority result;
            if (!_map.TryGetValue(code, out result))
                throw new InvalidCastException();
            return result;
        }
        private static readonly Dictionary<char, Priority> _map = new Dictionary<char, Priority>();
        private static void register(Priority p)
        {
            _map.Add(char.ToLowerInvariant(p._code), p);
            _map.Add(char.ToUpperInvariant(p._code), p);
        }
        private readonly char _code;
        private Priority(char code) { _code = code; }
    }

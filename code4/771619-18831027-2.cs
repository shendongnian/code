    // note that ((SomeIntegers)1) is a valid value with this scheme
    public enum SomeIntegers { Three = 3, Six = 6, Eight = 8, Eleven = 11 }
    // this stores the set of integers, but your logic to ensure the variable is
    // one of these values must exist elsewhere, e.g. in property getters/setters
    public ISet<int> SomeIntegers = new HashSet<int> {3,6,8,11};
    // this class is a pseudo-enum, and with the exception of reflection,
    // will ensure that only the specified values can be set
    public sealed class SomeIntegers
    {
        public static readonly SomeIntegers Three = new SomeIntegers(3);
        public static readonly SomeIntegers Six = new SomeIntegers(6);
        public static readonly SomeIntegers Eight = new SomeIntegers(8);
        public static readonly SomeIntegers Eleven = new SomeIntegers(11);
        public int Value { get; private set; }
        private SomeIntegers(int value)
        {
            this.Value = value;
        }
        public static implicit operator int(SomeIntegers someInteger)
        {
            return someInteger.Value;
        }
        public static explicit operator SomeIntegers(int value)
        {
            switch (value)
            {
                case 3:
                    return Three;
                case 6:
                    return Six;
                case 8:
                    return Eight;
                case 11:
                    return Eleven;
                default:
                    throw new ArgumentException("Invalid value", "value");
            }
        }
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }

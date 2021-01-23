    struct Indirect
    {
        private readonly int value;
        private Indirect(int value)
        {
            this.value = value;
        }
        public static Indirect Create(int value)
        {
            return new Indirect(value);
        }
    }
    
    struct Direct
    {
        private readonly int value;
        public Direct(int value)
        {
            this.value = value;
        }
    }
    
    class Program
    {
        static void Main()
        {
            var x = Indirect.Create(42);
            var y = new Direct(42);
        }
    }

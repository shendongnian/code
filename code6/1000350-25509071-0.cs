    public interface IMutable
    {
        void Mutate();
        int Value { get; }
    }
    public struct Evil : IMutable
    {
        public int value;
        public void Mutate()
        {
            value = 9;
        }
        public int Value { get { return value; } }
    }
    public static void Foo<T>(T mutable)
        where T : IMutable
    {
        mutable.Mutate();
        Console.WriteLine(mutable.Value);
    }
    static void Main(string[] args2)
    {
        Evil evil = new Evil() { value = 2 };
        Foo(evil);
    }

    struct Foo
    {
        public int Bar;
        public int Pop;
    }
    class Program
    {
        static void Main(string[] args) {
            Foo f;
            f.Bar = 3;
            test(f);        // ERROR: Use of unassigned local variable 'f'
        }
        static void test(Foo f) {
            Console.WriteLine("{0}", f.Bar);
        }
    }

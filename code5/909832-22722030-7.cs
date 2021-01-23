    interface I<T1, T2>
    {
        void M(T1 x, T2 y);
    }
    class A<T1, T2> : B<T1, T2>, I<T1, T2>
    {
        public void M(T1 x, T2 y)
        {
            Console.WriteLine("A: M({0}, {1})", x, y);
        }
    }
    class B<T1, T2> : I<T2, T1>
    {
        public void M(T2 x, T1 y)
        {
            Console.WriteLine("B: M({0}, {1})", x, y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A<int, int>();
            var b = new B<int, int>();
            var c = a as I<int, int>;
            var d = a as B<int, int>;
            a.M(0, 1); //Outputs "A: M(0, 1)"
            b.M(0, 1); //Outputs "B: M(0, 1)"
            c.M(0, 1); //Outputs "A: M(0, 1)" because I<T1, T2> takes precedence over I<T2, T1>
            d.M(0, 1); //Outputs "B: M(0, 1)" despite being called on an instance of A
            Console.ReadLine();
        }
    }

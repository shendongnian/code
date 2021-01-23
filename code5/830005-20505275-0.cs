    class Program
    {
        public delegate T Transformer<T>(T arg) where T : IComparable;
        static void Main(string[] args)
        {
            Transformer<int> method = Square;
            Console.WriteLine(method(5));
        }
        static int Square(int x)
        {
            return x * x;
        }
    }

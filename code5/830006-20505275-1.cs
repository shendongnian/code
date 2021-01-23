    class Program
    {
        public delegate T Transformer<T>(T arg) where T : IComparable;
        public static void Transform<T>(T value, Transformer<T> method) where T: IComparable
        {
            Console.WriteLine(method(value));
        }
        static void Main(string[] args)
        {
            Transform(5, Square);
        }
        static int Square(int x)
        {
            return x * x;
        }
    }

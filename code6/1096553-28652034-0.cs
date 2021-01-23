    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator<string>();
            Console.WriteLine(calc.Add(1,1));
        }
    }
    class Calculator<T>
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    class First
    {
        public void fun(ref int m)
        {
            m *= 10;
            Console.WriteLine("value of m = " + m);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            First f = new First();
            int x = 30;
            f.fun(ref x);
        }
    }

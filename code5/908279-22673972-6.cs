    class Program
    {
        static void Main()
        {
            dynamic obj = new Second<int>();
            Print(obj);
        }
        static void Print(object obj) { }
    }
    internal class First<T>
        where T : First<T> { }
    internal class Second<T> : First<Second<T>> { }

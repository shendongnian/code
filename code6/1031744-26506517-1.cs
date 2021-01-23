    class Program
    {
        static void Main(string[] args)
        {
            object list = new List<int> { 1, 2, 3 };
            Console.WriteLine((list as ICollection).IsNullOrEmpty());
        }
    }

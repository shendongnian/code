    class Program
    {
        static void Main(string[] args)
        {
            var obj = MyNamedObject.Instance;
            Console.WriteLine(obj.GetFullName());
        }
    }

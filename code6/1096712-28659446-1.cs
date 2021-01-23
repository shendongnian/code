    class Program
    {
        static void Main(string[] args)
        {
            // Here we create first an instance of our class, an object.
            var test = new Test();
            // Then we call our method.
            Console.WriteLine(test.Meth1());
            Console.ReadKey();
        }
    }

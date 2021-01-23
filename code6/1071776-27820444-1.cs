    class Program
    {
        static void Main(string[] args)
        {
            Foo f = new Foo();
            for (int i = 1; i <= 3; i++)
                try
                {
                    Console.WriteLine(f.GetBar(i));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            Console.ReadLine();
        }
    }

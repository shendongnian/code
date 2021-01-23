    namespace ConsoleApplication1
    {
        class Program
        {
            static bool again = true;
            static void Main(string[] args)
            {
                while (again)
                {
                    Random rnd = new Random();
                    int r = rnd.Next(0, 9);
                    int q = rnd.Next(0, 9);
                    int w = rnd.Next(0, 9);
                    Console.WriteLine(r);
                    Console.WriteLine(q);
                    Console.WriteLine(w);
                    ConsoleKeyInfo cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Q)
                        again = false;
                }
            }
        }
    }

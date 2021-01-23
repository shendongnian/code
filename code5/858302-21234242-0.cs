        static void Main(string[] args)
        {
            while (true)
            {
                Random rnd = new Random();
                int r = rnd.Next(0, 9);
                int q = rnd.Next(0, 9);
                int w = rnd.Next(0, 9);
                Console.WriteLine(r);
                Console.WriteLine(q);
                Console.WriteLine(w);
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key != ConsoleKey.Spacebar)
                {
                    break;
                }
            }
        }

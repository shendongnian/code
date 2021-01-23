        static void Main(string[] args)
        {
            using (var file = new System.IO.StreamWriter("c:\\Test.txt"))
            {
            double z = 0;
            double x = 1;
            double y = 1;
            Console.WriteLine("How many lines should be written to the file?");
            Console.WriteLine();
            z = double.Parse(System.Console.ReadLine());
            Console.WriteLine("Writing " + z + "lines to file!");
            Console.WriteLine();
            while (z > 0)
            {
                y = Math.Pow(x, 2);
                Console.WriteLine(x + ", " + y*10);
                file.WriteLine(x + ", " + y*10);
                z = z - 1;
                x = x + 1;
            }
            Console.WriteLine();
            Console.WriteLine("**Generation Complete**");
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Console.WriteLine("**Writing to file successful**");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            }
        }

       static void Main(string[] args)
        {
            var rh = new RandomHash(5000);
            Console.WriteLine(rh.HashNumber(1));
            Console.WriteLine(rh.HashNumber(2));
            Console.WriteLine(rh.HashNumber(3));
            Console.WriteLine(rh.HashNumber(1000));
            Console.WriteLine(rh.HashNumber(2));
            Console.WriteLine(rh.HashNumber(1));
            Console.WriteLine();            
        }

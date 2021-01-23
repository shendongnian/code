    class Program
    {
        static void Main(string[] args)
        {
            double dblMyNumber = 0;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int j = 0; j < 20; j++) {
                dblMyNumber = rnd.Next(1, 4);
                dblMyNumber += ((double)rnd.Next(10))/10;
                Console.WriteLine(dblMyNumber.ToString("0.0"));
            }
            Console.ReadLine();
        }
    }

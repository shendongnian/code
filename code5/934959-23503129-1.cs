    class Program
    {
        static void Main(string[] args)
        {
            float fMyNumber = 0;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int j = 0; j < 20; j++) {
                fMyNumber = rnd.Next(1, 4);
                fMyNumber += ((float)rnd.Next(10)) / 10;
                Console.WriteLine(fMyNumber.ToString("0.0"));
            }
            Console.ReadLine();
        }
    }

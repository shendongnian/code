    class Program
    {
        static void Main(string[] args)
        {
            double total = 0;
            double avg = 0;
            
            double[] Yahoo = { 1, 2, 3, 4,5 };
            for (int i = 0; i < Yahoo.Length; i++)
            {
                total += Yahoo[i];
            }
            avg = total / Yahoo.Length;
            Console.WriteLine(avg);
            Console.ReadKey();
        }
    }

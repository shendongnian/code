        static void Main(string[] args)
        {
            Console.WriteLine(RoundValueToNext100(589.62));
            Console.ReadLine();
        }
        private static int RoundValueToNext100(double value)
        {
            int result = (int)Math.Round(value / 100, 0, MidpointRounding.AwayFromZero);
            if (value > 0 && result == 0)
            {
                result = 1;
            }
            return (int)result * 100;
        }

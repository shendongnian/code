    class Program
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            // ... code ...
            for (int i = 0; i < 9; i++)   // populate the array  with 10 random values
            {
                int randomNumber = random.Next(1, 50);
                personalNumbers[i] = randomNumber.ToString();
            }
            // ... code ...
        }
    }

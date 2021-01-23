    class Program
    {
        static void Main(string[] args)
        {
            List<int> predefinedIntsList = new List<int>() { 1, 3, 4, 8, 9 };
            Random rnd = new Random();
            List<int> newIntsList = new List<int>();
            int upperBound = 10;
            for (int i = 0; i < upperBound; i++)
            {
                if (!predefinedIntsList.Contains(i))
                {
                    newIntsList.Add(i);
                }
            }
            for (int i = 0; i < 20; i++)
            {
                int newRandomValueIndex = rnd.Next(0, newIntsList.Count);
                int newRandomValue = newIntsList[newRandomValueIndex];
                Console.WriteLine(newRandomValue);
                
            }
        }
    }

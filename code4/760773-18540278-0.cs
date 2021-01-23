    static void Main(string[] args)
    {
        for (int i = 2; i < 1001; i++)
        {
            bool IsItAPerfectNum = IsItPerfect(i);
            if (IsItAPerfectNum)
            {
                Console.WriteLine("{0} is a perfect number", i);
                Console.ReadKey(true);
            }
        }
    }

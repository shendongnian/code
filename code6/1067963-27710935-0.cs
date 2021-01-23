    public static List<int> GetRandomNumbers(int count)
    {
        List<int> Result = new List<int>();
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            int NewNumber = random.Next(100, 999);
            Result.Add(NewNumber);
            Result.Add(NewNumber);
        }
        return Result;
    }

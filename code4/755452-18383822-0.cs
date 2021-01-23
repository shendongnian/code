    static void Main(string[] args)
    {
        Console.WriteLine(Find());
    }
    public static int Find()
    {
        int number = 0;
        for (int i = 1; ; i++)
        {
            number += i; // number is triangle number i
            if (CountDivisorsOfNumber(number) > 500)
                return number;
        }
    }
    private static int CountDivisorsOfNumber(int number)
    {
         int count = 0;
         int end = (int)Math.Sqrt(number);
         for (int i = 1; i < end; i++)
         {
             if (number % i == 0)
                 count += 2;
         }
         if (end * end == number) // Perfect square
             count++;
         return count;
    }

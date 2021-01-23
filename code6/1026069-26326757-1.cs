    public static void myString(int n, int lowerBound, int uppedBound)
    {
        Random rand = new Random();
        for (int i = 1; i <= n; i++)
        {
            int x = rand.Next(lowerBound, upperBound); // Changed here.
            char c = (char)x;
            Console.Write(c);
        }
        Console.WriteLine();
    }
    public static void myLowerCaseString(int n)
    {
        myString (97, 122);
    }
    public static void myUpperCaseString(int n)
    {
        myString (65, 90);
    }

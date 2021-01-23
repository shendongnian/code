    public static int FibHugesUntil(BigInteger huge1, BigInteger huge2, int reqDigits)
    {
        int number = 1;
        while (huge2.ToString().Length < reqDigits)
        {
            var huge3 = huge1 + huge2;
            huge1 = huge2;
            huge2 = huge3;
            number++;
        }
        return number;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(FibHugesUntil(BigInteger.Zero, BigInteger.One, 1000));
    }

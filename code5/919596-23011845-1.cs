    static void Main(string[] args)
    {
        Random random = new Random();
        for (int i = 0; i < 100; i++)
            Console.WriteLine(GetVoucherNumber(6, random));
        Console.ReadLine();
    }
    public static string GetVoucherNumber(int length, Random random)
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var result = new string(
            Enumerable.Repeat(chars, length)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
        return result;
    }

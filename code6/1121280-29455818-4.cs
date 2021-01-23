    public static string stevilo()
    {
        Console.WriteLine("Enter your number! ");
        string vnos = Console.ReadLine();
        int x = Convert.ToInt32(vnos);
        StringBuilder sb = new StringBuilder();
        var list = Enumerable.Range(0, 1000)
                             .Where(z => z.ToString()
                             .ToCharArray()
                             .Sum(c => c - '0') == x);
        return string.Join(",", list);
    }

    public static void Main()
    {
        var string1 = "001000\n000100\n000100";
        var string4 = "10001000\n00100100\n00000100";
        var string2 = "10\n01\n01";
        var string3 = "010\n010\n010";
        Console.WriteLine(string1.MultiContains(string2));
        Console.WriteLine(string1.MultiContains(string3));
        Console.WriteLine(string4.MultiContains(string2));
        Console.WriteLine(string4.MultiContains(string3));
    }

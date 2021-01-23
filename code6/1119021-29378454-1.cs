    static void Main(string[] args)
    {
        Console.WriteLine(Levenshtein.FindDistance("Alois", "aloisdg"));
        Console.WriteLine(Levenshtein.FindDistance("Alois", "aloisdg", true));
        Console.ReadLine();
    }

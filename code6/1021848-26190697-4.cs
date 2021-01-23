    static void Main(string[] args)
    {
        Console.WriteLine(String.Compare(LexicallySortable(Int64.MinValue), LexicallySortable(-2)));
        Console.WriteLine(String.Compare(LexicallySortable(-2), LexicallySortable(-1)));
        Console.WriteLine(String.Compare(LexicallySortable(-1), LexicallySortable(0)));
        Console.WriteLine(String.Compare(LexicallySortable(0), LexicallySortable(1)));
        Console.WriteLine(String.Compare(LexicallySortable(1), LexicallySortable(Int64.MaxValue)));
        Console.ReadLine();
    }

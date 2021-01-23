    string s = "bread";
    for(int i = 1; i < s.Length; i++)
    {
        Console.WriteLine(s.Substring(0, i)); //prefix
        Console.WriteLine(s.SubString(i, s.Length - i)); //suffix
    }

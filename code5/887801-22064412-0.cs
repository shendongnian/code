    string s = " وَجَلَّ فی ";
    foreach (char c in s)
    {
        Console.Write(c);
        Console.WriteLine(Char.GetUnicodeCategory(c));
    }

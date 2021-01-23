    for (int i=0; i < 9999; ++i)
    {
        string s = i.ToString("0000");
        if (!s.Contains("9"))
            Console.WriteLine(s);
    }

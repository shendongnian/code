    string name = "John Smith";
    string[] nameParts = name.Split(' ');
    nameParts[0] = nameParts[0].Substring(0, 1);
    string abbrName = String.Join(" ", nameParts);
    Console.WriteLine(abbrName);

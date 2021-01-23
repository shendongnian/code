    for (int column = 0; column < original.Length; column++)
    {
        string row = string.Join(",", original.Select(o => o[column]));
        Console.WriteLine(row);    
    }

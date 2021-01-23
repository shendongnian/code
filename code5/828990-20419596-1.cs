    string str = "column111.dwg&186&0;";
    string[] singleStr = str.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
    foreach (var item in singleStr)
    {
        Console.WriteLine(item);
    }

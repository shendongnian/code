    string str = "SJL1036";
    if (str.Length == 7 &&
        str.Take(3).All(char.IsUpper)
        && str.Skip(3).All(char.IsDigit))
    {
        Console.WriteLine("valid");
    }
    else
    {
        Console.WriteLine("invalid");
    }

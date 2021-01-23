    string InputString = "5+6+12+33+1+9+";
    string[] SeparatedIDs = InputString.Split(new[] { '+' }, 
        StringSplitOptions.RemoveEmptyEntries);
    foreach (string SeparatedID in SeparatedIDs)
        Console.WriteLine(SeparatedID);

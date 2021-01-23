    string[] FirstSeparator = new[] {"nosyn_name_last_exact:(qxq"};
    string[] SecondSeparator = new[] {"qxq)"};
    foreach (string line in File.ReadLines(sourceFile))
    {
        var temp = source.Split(FirstSeparator, StringSplitOptions.RemoveEmptyEntries)[1];
        var result = temp.Split(SecondSeparator, StringSplitOptions.RemoveEmptyEntries)[0];
        //or any other output ....
        result.Dump("Result: ");
    }
    

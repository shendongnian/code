    while (!inFile.EndOfStream)
        {
            inValue = inFile.ReadLine()
            myCount = System.Text.RegularExpressions.Regex.Matches(inValue, "NONE").Count;
         }
        Console.WriteLine("NONE occurs {0} time(s).", myCount);

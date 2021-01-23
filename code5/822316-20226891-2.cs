    string[] stringhe = new string[5] {
        "This is a test No. 42, Hello Nice People",
        "I have no idea wtf No. 1234412344124. I am doing.",
        "Very long No.                        74385748957348957893458934; Hello World",
        "Nope No. 48394839!!!",
        "Nope"
    };
    
    Regex reg = new Regex(@"No.\s*([0-9]+)");
    
    Match match;
    int idx = 0;
    
    StringBuilder builder;
    foreach(string stringa in stringhe)
    {
        match = reg.Match(stringa);
    
        if (match.Success)
        {
            Console.WriteLine("No. Stringa #" + idx + ": " + stringhe[idx]);
    
            int indexEnd = match.Groups[1].Index + match.Groups[1].Length;
    
            builder = new StringBuilder(stringa);
            builder[indexEnd] = '.';
    
            stringhe[idx] = builder.ToString();
            Console.WriteLine("New String: " + stringhe[idx]);
        }
    
        ++idx;
    }
    
    Console.ReadKey(true);

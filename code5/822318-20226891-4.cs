    string[] stringhe = new string[4] {
        "This is a test No. 42, Hello Nice People",
        "I have no idea wtf No. 1234412344124. I am doing.",
        "Very long No. 74385748957348957893458934; Hello World",
        "Nope No. 48394839!!!"
    };
    
    Regex reg = new Regex(@"No.\s+([0-9]+)");
    
    Match match;
    int idx = 0;
    foreach(string stringa in stringhe)
    {
        match = reg.Match(stringa);
    
        if (match.Success)
        {
            Console.WriteLine("No. Stringa #" + idx + ": " + match.Groups[1].Value);
        }
    
        ++idx;
    }

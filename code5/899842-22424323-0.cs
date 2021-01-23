    string[] names = new string[]
    {
        "1. Anton 30p",
        "2. Cinderella 20p",
        "3. Thomas 18p",
        "4. Anastacia-Laura 16p"
    };
    
    foreach(string s in names)
    {
        int lastSpace = s.LastIndexOf(' ');
        int firstSpace = s.IndexOf(' ');
        string result = string.Format("{0,-4}{1,-37}{2,4}", s.Substring(0, firstSpace), s.Substring(firstSpace + 1, lastSpace), s.Substring(lastSpace+1));
        Console.WriteLine(result);
    
    }

    string x = "0000000100000002000000003";
    
    List<string> a = new List<string>();
    for (int i = 0; i < x.Length; i += 8)
    {
        if((i + 8) < x.Length)
            a.Add(x.Substring(i, 8));
        else
            a.Add(x.Substring(i));
    }

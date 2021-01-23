    string s = "Q1123null";
    string First,Second,Third;
    First = s[0].ToString();
    Second = s.Substring(1,s.Length-5);
    Third = s.Substring(s.Length-4);
    Console.WriteLine (First);
    Console.WriteLine (Second);
    Console.WriteLine (Third);

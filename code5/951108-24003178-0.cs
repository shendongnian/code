    string s = "[a-zA-Z0-9]";
    Regex rgx = new Regex(s);
    string s = "dune";
    string result = rgx.Replace(s, "-");
    
    Console.WriteLine(result);
    Console.Read();

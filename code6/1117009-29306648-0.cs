    string x="2+3-45.3+9";
    string pattern = @"([+\-*/])";
    var tokens = Regex.Split(x, pattern).Where(i => !string.IsNullOrEmpty(i)).ToList();
    
    Console.WriteLine(tokens.Count);

    string[] inputs = 
    {
        "example1",
        "examDontMatchMeple2",
        "example3",
        "examDontMatchMeple4",
        "example4"
    };
    
    string ignoreText = "DontMatchMe";
    string pattern = String.Format("^(?!.*{0}).+", Regex.Escape(ignoreText));
    
    foreach (var input in inputs)
    {    
        Console.WriteLine("{0}: {1}", input, Regex.IsMatch(input, pattern));
    }

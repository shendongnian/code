    string s = "aa bb cc dd ee ff gg hh ii kk";
    var index = -1;
    for (int i = 0; i < 5; i++)
    {
        index = s.IndexOf(" ", index + 1);
    }
    
    string output = s.Remove(index);
    Console.WriteLine(output); // "aa bb cc dd ee"

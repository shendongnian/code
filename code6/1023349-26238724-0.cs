    string role = "OW";
    string str = "Bob Green;PD,Andy Richards;BD,Frank Williams;OW,James Clack;PM";
    string pattern = "([^,]*);" + role;
    var match = Regex.Match(str, pattern);
    if (match.Success)
    {
        Console.WriteLine(match.Groups[1].Value);
    }

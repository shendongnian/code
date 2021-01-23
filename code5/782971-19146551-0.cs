    string line = "Print date :6/19/2013 11:31:55 AM";
    int pos = line.IndexOf(':');
    if(pos >= 0)
    {
        line = line.Substring(0, pos + 1);
        Console.WriteLine(line);
    }

    Regex re = new Regex(@"\s(\S*?)$");
    foreach (var line in s.Split(new[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
    {
        Match m = re.Match(s);
        Console.WriteLine("{0},{1},'{2}'", m.Index, m.Length, m.Groups[1].Value);
    }

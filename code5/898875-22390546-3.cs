    const string fname = @"C:\mystuff\program.exe";
    using (var sw = new StreamReader(fname, Encoding.GetEncoding("windows-1252")))
    {
        var s = sw.ReadToEnd();
        s = s.Replace('\x0', ' '); // replace NUL bytes with spaces
        Console.WriteLine(s);
    }

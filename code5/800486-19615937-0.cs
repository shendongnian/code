    string line;
    using (var sr = new StreamReader(@"E:\test1.txt"))
    {
        using (var sw = new StreamWriter(@"E:\test1.tmp"))
        {
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                line = Regex.Match(line, @"([\d]*)").Groups[1].Value;
                sw.WriteLine(line);
            }
        }
    }
    File.Replace(@"E:\test1.tmp", @"E:\test1.txt", null);

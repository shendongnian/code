    string line;
    using (var file = new StreamReader(as400file))
    {
        line = file.ReadLine();
    }
    string replaced = Regex.Replace(line, @"[^\u0000-\u007F]", String.Empty);

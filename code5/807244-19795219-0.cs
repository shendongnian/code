    using (var reader = new System.IO.StreamReader(as400File))
    {
        var line = reader.ReadLine();
        string replaced = Regex.Replace(line, @"[^\u0000-\u007F]", String.Empty);
    }

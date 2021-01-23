    using (var sw = new StreamWriter(filename))
    {
        foreach (something in somethingElse)
        {
            string line = "compute this line somehow";
            sw.WriteLine(line);
        }
    }

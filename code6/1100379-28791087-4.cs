    using (var sr = new StreamReader("somefile"))
    {
        // Little LINQ to strip excess \r
        // (note that the file will be read line by line, so only
        // a line at a time is in memory (plus some remaining characters
        // of the next line in the old buffer)
        IEnumerable<string> lines = sr.ReadLines("\r\n").Select(x => x.TrimEnd('\r'));
        foreach (string line in lines)
        {
            // Do something
        }
    }

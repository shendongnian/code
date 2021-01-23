    using (var sr = new StreamReader("somefile"))
    {
        IEnumerable<string> lines = sr.ReadLines("\r\n").Select(x => x.TrimEnd('\r'));
        foreach (string line in lines)
        {
            // Do something
        }
    }

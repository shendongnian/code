    List<string> buffer = new List<string>();
    using (var sin = new StreamReader("pathtomylogfile")) 
    {
        string line;
        bool read;
        while ((line = sin.ReadLine())!=null) 
        {
            if (line.Contains("keyword"))
            {
                buffer.Clear();
                read = true;
            }
            if (read)
            {
                buffer.Add(line);
            }
        }
        // now buffer has the last entry
        // you could use string.Join to put it back together in a single string
        var lastEntry = string.Join("\n",buffer);
    }

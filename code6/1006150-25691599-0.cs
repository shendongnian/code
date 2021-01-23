    using (var sr = new StreamReader(source))
    {
        string line;
        int linesToSkip = 0;
        while ((line = sr.ReadLine()) != null)
        {
            if (linesToSkip > 0)
            {
                linesToSkip -= 1;
                continue;
            }
            if (line == "Section 1-1")
            {
                // skip the next 3 iterations (lines)
                linesToSkip = 3;
            }  
        }
    }

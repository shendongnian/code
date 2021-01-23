    string line;
    while ((line = sr.ReadLine()) != null)
    {
        if (line == "Section 1-1")
        {
            DiscardLines(sr, 3);
        }
    }

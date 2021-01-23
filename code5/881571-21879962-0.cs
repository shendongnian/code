    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();
        if (line.StartsWith("0"))
        {
            continue;
        }
        //process line logic
    }

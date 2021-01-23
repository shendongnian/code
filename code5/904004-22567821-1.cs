    string[] selectedLines = new int[M];
    int numLines = 0;
    Random rnd = new Random();
    foreach (var line in File.ReadLines(filename))
    {
        ++numLines;
        if (numLines <= M)
        {
            selectedLines[numLines-1] = line;
        }
        else
        {
            double prob = (double)M/numLines;
            if (rnd.Next() >= prob)
            {
                int ix = rnd.Next(M);
                selectedLines[ix] = line;
            }
        }
    }

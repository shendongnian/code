    Random rnd = new Random();
    var lines = File.ReadAllLines(path1);
    for (int i = 0; i < value; i++)
    {
        if (i % lines.Length == 0)
        {
            // We after using all the rows once
            // we used all of them (or at the beginning)
            // Shuffle, Fischer-Yates 
            int n = lines.Length;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                string value2 = lines[k];
                lines[k] = lines[n];
                lines[n] = value2;
            }
        }
        var line = lines[i % lines.Length];
        StringBuilder b = new StringBuilder();
        for (int j = 0; j < line.Length; j++)
        {
            char c = line[j];
            if (rnd.Next(2) == 0)
            {
                c = Char.ToUpper(c);
            }
            b.Append(c);
            if (j % 2 == 1)
            {
                b.Append(rnd.Next(10));
            }
        }
        line = b.ToString();
        Directory.CreateDirectory(Path.Combine(path, line));
    } 

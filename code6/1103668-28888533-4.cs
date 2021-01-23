    if (path != null && Directory.Exists(path))
        Random rnd = new Random();
        for (int i = 0; i < value; i++)
        {
            var lines = File.ReadAllLines(@"M:\\dictionar.txt");
            var randomLineNumber = rnd.Next(0, lines.Length);
            var line = lines[randomLineNumber];
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
    }

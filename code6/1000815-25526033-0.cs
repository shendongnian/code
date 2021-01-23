        List<string[]> parts = new List<string[]>();
        foreach (string line in lines)
        {
            parts.add(line.Split(','));
        }
        foreach (string[] part in parts)
        {
           foreach (string p in part)
           {
             Console.WriteLine(p);
           }
        }

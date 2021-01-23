    public static int[,] LoadFromFile(string filename)
    {
        var pairs = new Dictionary<int, List<int>>();
        using (var reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var elems = line.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                if (elems.Length <= 1)
                    break;
                var froms = elems[0].Split(',').Select(x => int.Parse(x)).ToList();
                var tos = elems[1].Split(',').Select(x => int.Parse(x)).ToList();
                foreach (var from in froms)
                {
                    if (!pairs.ContainsKey(from))
                        pairs.Add(from, new List<int>());
                    foreach (var to in tos)
                    {
                        if (!pairs.ContainsKey(to))
                            pairs.Add(to, new List<int>());
                        pairs[from].Add(to);
                        pairs[to].Add(from);
                    }
                }
            }
        }
        var size = pairs.Keys.Max() + 1;
        var edges = new int[size, size];
        foreach(var p in pairs.SelectMany(x => x.Value.Select(y => new { x = x.Key, y})))
        {
            edges[p.x, p.y] = 1;
        }
        return edges;
    }

        var wspace = new List<Tuple<int, int>>();
        string[,] cells = { {" "," "," ","F"}, {"F","F","F"," "}, {" "," ","F"," "} };
        
        for (int i = 0; i < cells.GetLength(0); i++)
            for (int j = 0; j < cells.GetLength(1); j++)
                if (cells[i, j] == " ")
                    wspace.Add(new Tuple<int,int>(i,j));
        var region = new List<Tuple<int, int>>();
        var regions = new List<List<Tuple<int, int>>>();
        int iout = 0;
        region.Add(wspace.First());
        foreach (Tuple<int, int> pos in wspace.Skip(1))
        {
            bool keep = true;
            for (int i = -1; i < 2 && keep; i++)
            {
                for (int j = -1; j < 2 && keep; j++)
                {
                    if (region.Where(x => x.Item1 == (pos.Item1 + i) && x.Item2 == (pos.Item2 + j)).Count() > 0)
                    {
                        region.Add(pos);
                        keep = false;
                    }
                }
            }
            if (!keep) continue;
            iout++;
            if (iout == (cells.GetLength(1) + 1))
            {
                regions.Add(region);
                region.Clear();
                iout = 0;
            }
        }
        regions.Add(region);
        region = regions.OrderBy(x => x.Count).Last();
        region.ForEach(x => Console.WriteLine("Array: {0} Key: {1}", x.Item1 + 1, x.Item2 + 1));

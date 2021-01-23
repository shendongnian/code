                var wspace = new List<Tuple<int, int>>();
                string[,] cells = { 
                   { "F", " ", "F", "F", "F", "F", " " }, 
                   { "F", "F", "F", " ", "F", "F", " " }, 
                   { "F", " ", "F", " ", "F", " ", "F" },
                   { "F", "F", " ", "F", "F", " ", "F" },
                   { "F", " ", "F", " ", "F", " ", "F" }
               };
    
                for (int i = 0; i < cells.GetLength(0); i++)
                    for (int j = 0; j < cells.GetLength(1); j++)
                        if (cells[i, j] == " ")
                            wspace.Add(new Tuple<int, int>(i, j));
    
                var region = new List<Tuple<int, int>>();
                var pre = new List<Tuple<int, int>>();
                var regions = new List<List<Tuple<int, int>>>();
                region.Add(wspace.First());
                wspace = wspace.Skip(1).ToList();
    
                for(int z=0; z<wspace.Count(); z++)
                {
                    var pos = wspace[z];
                    bool keep = true;
                    for (int i = -1; i < 2 && keep; i++)
                    {
                        for (int j = -1; j < 2 && keep; j++)
                        {
                            if (region.Any(x => x.Item1 == (pos.Item1 + i) && x.Item2 == (pos.Item2 + j)))
                            {
                                pre.Reverse();
                                wspace.AddRange(pre);
                                pre.Clear();
                                region.Add(pos);
                                keep = false;
                            }
                        }
                    }
    
                    if (keep && (pos.Item1 > region.Last().Item1) && (pos.Item2 > region.Last().Item2))
                    {
                        regions.Add(region.ToList());
                        region.Clear();
                        region.Add(pos);
                    }
                    else if (keep) pre.Add(pos);
    
                }
                regions.Add(region);
                region = regions.OrderBy(x => x.Count).Last().OrderBy(s => s.Item1 * cells.GetLength(1) + s.Item2).ToList();
    
                region.ForEach(x => Console.WriteLine("Array: {0} Key: {1}", x.Item1 + 1, x.Item2 + 1));

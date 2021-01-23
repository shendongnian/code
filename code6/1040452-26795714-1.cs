                var lines = File.ReadAllLines(@"Linq.csv").Select(x => x.Split(','));
                //Considering each line contains same no. of elements
                int lineLength = lines.First().Count();  
                var CSV = lines.Skip(1)
                           .SelectMany(x => x)
                           .Select((v, i) => new { Value = v, Index = i % lineLength })
                           .Where(x => x.Index == 2 || x.Index == 3)
                           .Select(x => x.Value);
                foreach (var data in CSV)
                {
                    Console.WriteLine(data);
                }

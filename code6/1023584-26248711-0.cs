                String[] Teams = { 
                   "TeamC", "TeamB", "TeamA"
                };
    
                int[] Scores = { 
                    0, 1, 2
                };
    
                var sortedTest = Teams
                    .Select((x, i) => new KeyValuePair<string, int>(x.ToString(), i))
                    .OrderBy(x => x.Key)
                    .ToList();
    
                String[] TeamsSorted = sortedTest.Select(x => x.Key).ToArray();
                List<int> idx = sortedTest.Select(x => x.Value).ToList();
    
                List<int> sortedScores = new List<int>();
                for (int i = 0; i < idx.Count; i++)
                {
                    sortedScores.Add(Scores[idx[i]]);
                }
    
                Console.WriteLine("Sorted Teams: ");
                TeamsSorted.ToList().ForEach((m) => Console.WriteLine(m));
    
                Console.WriteLine("Sorted Scores: ");
                sortedScores.ToList().ForEach((m) => Console.WriteLine(m));

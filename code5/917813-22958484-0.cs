            var l = new List<string>();
            using (var fs = new FileStream("", FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        l.Add(line);
                    }
                }
            }
            Parallel.ForEach(l, new ParallelOptions {MaxDegreeOfParallelism = 10}, line => Console.WriteLine(line));

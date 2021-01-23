            // using System.Linq;
            string[] raw = new string[] { "alpha", "beta", "gamma", "delta" };
            List<int> evenIndices = Enumerable.Range(0, raw.Length)
                .Where(x => x % 2 == 0)
                .ToList();
            foreach (int x in evenIndices)
                raw[x] = raw[x] + " (even)";
            foreach (string x in raw)
                Console.WriteLine(x);
            /*
            OUTPUT: 
             
            alpha (even)
            beta
            gamma (even)
            delta
            */

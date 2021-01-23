      private static int[,] HipPriestsHomework()
        {
            string y = "11110000";
            Console.WriteLine(y);
            var rules = new[]
            {
                new {pattern = 0, result = 0},
                new {pattern = 1, result = 1},
                new {pattern = 2, result = 1},
                new {pattern = 3, result = 1},
                new {pattern = 4, result = 1},
                new {pattern = 5, result = 0},
                new {pattern = 6, result = 0},
                new {pattern = 7, result = 0},
            };
            Dictionary<int, int> rulesLookup = new Dictionary<int, int>();
            foreach(var rule in rules)
            {
                rulesLookup.Add(rule.pattern, rule.result);
            }
            int numGenerations = 10;
            int inputSize = y.Length;
            int[,] output = new int[numGenerations, inputSize];
            int[] items = new int[y.Length];
            for(int inputIndex = 0; inputIndex< y.Length; inputIndex++)
            {
                string token = y.Substring(inputIndex, 1);
                int item = Convert.ToInt32(token);
                items[inputIndex] = item;
            }
                        
            int[] working = new int[items.Length];
            items.CopyTo(working, 0);
            for (int generation = 0; generation < numGenerations; generation++)
            {
                for (uint y_scan = 0; y_scan < items.Length; y_scan++)
                {
                    int a = items[(y_scan - 1) % items.Length];
                    int b = items[y_scan % items.Length];
                    int c = items[(y_scan + 1) % items.Length];
                    int pattern = a << 2 | b << 1 | c;
                    var match = rules[pattern];
                    output[generation, y_scan] = match.result;
                    working[y_scan] = match.result;
                    Console.Write(match.result);
                }
                working.CopyTo(items, 0);
                Console.WriteLine();
            }
            
            return output;
        }

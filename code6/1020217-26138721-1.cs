        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var trie = new Trie<KeyValuePair<string,int>>();
            //build trie with your value pairs
            var lines = File.ReadLines("en.txt");
            foreach(var line in lines.Take(100000))
            {
                var split = line.Split(' ');
                trie.Add(split[0], new KeyValuePair<string,int>(split[0], int.Parse(split[1])));
            }
            Console.WriteLine("Time needed to read file and build Trie with 100000 words: " + sw.Elapsed);
            sw.Reset();
            //test with 10000 search words
            sw.Start();
            foreach (string line in lines.Take(10000))
            {
                var searchWord = line.Split(' ')[0];
                var allPairs = trie.Retrieve(searchWord);
                var bestWords = allPairs.OrderByDescending(kv => kv.Value).ThenBy(kv => kv.Key).Select(kv => kv.Key).Take(10);
                var output = bestWords.Aggregate("", (s1, s2) => s1 + ", " + s2);
                Console.WriteLine(output);
            }
            Console.WriteLine("Time to process 10000 different searchWords: " + sw.Elapsed);
        }

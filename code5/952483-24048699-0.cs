        //key is target, values are the sources
        private static readonly ConcurrentDictionary<string, HashSet<string>> targetMap = new ConcurrentDictionary<string, HashSet<string>>();
        private static void Add(string source, string target)
        {
            var node = targetMap.GetOrAdd(target, new HashSet<string>());
            node.Add(source);
        }
        public static IEnumerable<KeyValuePair<string, string>> FindTarget(string destination, bool recursive = true)
        {
            HashSet<string> node;
            if (targetMap.TryGetValue(destination, out node))
            {
                foreach (var source in node)
                {
                    if (recursive)
                    {
                        foreach (var child_route in FindTarget(source))
                        {
                            yield return child_route;
                        }
                    }
                    yield return new KeyValuePair<string, string>(source, destination);
                }
            }
        }
        public static void Main()
        {
            Add("a", "b");
            Add("y", "a");
            Add("q", "b");
            Add("d", "x");
            Add("b", "d");
            Add("r", "q");
            Add("c", "b");
            foreach (var route in FindTarget("x"))
            {
                Console.WriteLine("{0} -> {1}", route.Key, route.Value);
            }
        }

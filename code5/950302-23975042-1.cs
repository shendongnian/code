    internal class Program
    {
        private static IEnumerable<IEnumerable<int>> Subsets(int n, int subsetSize)
        {
            IEnumerable<int> sequence = Enumerable.Range(1, n);
            // generate list of sequences containing only 1 element e.g. {1}, {2}, ...
            var oneElemSequences = sequence.Select(x => new[] { x }).ToList();
            // generate List of int sequences
            var result = new List<List<int>>();
            // add initial empty set
            result.Add(new List<int>());
            // generate powerset, but skip sequences that are too long
            foreach (var oneElemSequence in oneElemSequences)
            {
                int length = result.Count;
                for (int i = 0; i < length; i++)
                {
                    if (result[i].Count >= subsetSize)
                        continue;
                    result.Add(result[i].Concat(oneElemSequence).ToList());
                }
            }
            return result.Where(x => x.Count == subsetSize);
        }
        private static void OutputSubset(int n, IEnumerable<IEnumerable<int>> subsets)
        {
            Console.WriteLine("n: {0}", n);
            foreach (var subset in subsets)
            {
                Console.WriteLine("\t{0}", string.Join(" ", subset.Select(x => x.ToString())));
            }
        }
        private static void Main()
        {
            for (int n = 1; n < 500; n++)
            {
                var subsets = Subsets(n, subsetSize: 4);
                OutputSubset(n, subsets);
            }
        }
    }

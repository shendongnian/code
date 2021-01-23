    internal class Program
    {
        private static IEnumerable<IEnumerable<int>> Powerset(IEnumerable<int> sequence)
        {
            // generate list of sequences containing only 1 element e.g. {1}, {2}, ...
            var oneElemSequences = sequence.Select(x => new[] { x }).ToList();
            // generate List of int sequences
            var result = new List<IEnumerable<int>>();
            // add initial empty set
            result.Add(new int[0]);
            // generate powerset
            foreach (var oneElemSequence in oneElemSequences)
            {
                var copy = result.ToList();
                foreach (var previousSequence in copy)
                {
                    result.Add(previousSequence.Concat(oneElemSequence));
                }
            }
            return result;
        }
        private static void Main()
        {
            int n = 5;
            int subsetSize = 4;
            var subsets = Powerset(Enumerable.Range(1, n)).Where(x => x.Count() == subsetSize);
            foreach (var set in subsets)
            {
                Console.WriteLine(string.Join(" ", set.Select(x => x.ToString())));
            }
            Console.ReadLine();
        }
    }

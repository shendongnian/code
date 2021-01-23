     class Program
    {
        static void Main(string[] args)
        {
            foreach (var set in GetCombinations(3, 9))
            {
                Console.WriteLine("{{{0}}}", string.Join(",", set));
            }
            Console.ReadKey();
        }
        public static IEnumerable<IEnumerable<int>> GetCombinations(int length, int targetSum)
        {
            var combinations = Enumerable.Range(1, length)
                .Select(x => Enumerable.Range(1, targetSum - length+1)).CartesianProduct();
            combinations=combinations
                .Where(x => x.Sum(y => y) == targetSum);
            return combinations.Distinct(new Comparer()).ToList();
        }
    }
    public class Comparer : IEqualityComparer<IEnumerable<int>>
    {
        public bool Equals(IEnumerable<int> x, IEnumerable<int> y)
        {
            var isEqual= x.OrderBy(a => a).SequenceEqual(y.OrderBy(b => b));
            return isEqual;
        }
        public int GetHashCode(IEnumerable<int> obj)
        {
            return obj.Sum(); //lazy me, just indicate collection is same if their sum is same.
        }
    }
    public static class Extensions
    {
       public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                    from accseq in accumulator
                    from item in sequence
                    select accseq.Concat(new[] { item }));
        }
    }

    public class Comparer : IComparer<IEnumerable<int>>
    {
        public int Compare(IEnumerable<int> a, IEnumerable<int> b)
        {
            var aOrdered = a.OrderByDescending(i => i).Concat(new[] { int.MinValue });
            var bOrdered = b.OrderByDescending(i => i).Concat(new[] { int.MinValue });
            return a.Zip(b, (i, j) => i.CompareTo(j)).FirstOrDefault(c => c != 0);
        }
    }

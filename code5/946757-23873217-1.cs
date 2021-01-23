    var numList = new List<int>() { 12, 33, 24, 63, 45, 32, 3, 18, 22, 7, 10 };
    var combinations = from x in numList
                from y in numList
                from z in numList
                from t in numList
                select new [] {x, y, z, t};
    var result =  combinations
                 .Where(x =>  x.Sum() > 100 && x.Distinct().Count() == x.Length);
    var distinctResults = result.Distinct(new Comparer()).ToList();
    public class Comparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            return x.OrderBy(a => a).SequenceEqual(y.OrderBy(a => a));
        }
        public int GetHashCode(int[] obj)
        {
            return obj.Select(x => x.GetHashCode()).Sum();
        }
    }

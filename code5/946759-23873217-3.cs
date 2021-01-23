    var numList = new List<int>() { 12, 33, 24, 63, 45, 32, 3, 18, 22, 7, 10 };
    /* get all combinations including duplicates like: 
    12,12,12,12 - 12,12,12,34 - 12,12,12,24  and so on
    then put them into an array int[] */
    var combinations = from x in numList
                from y in numList
                from z in numList
                from t in numList
                select new [] {x, y, z, t};
    /* eliminate the duplicates (like 12-12-12-12) and 
       filter them based on Sum */
    var result =  combinations
                 .Where(x => x.Sum() > 100 && x.Distinct().Count() == x.Length);
    // get distinct combinations using a custom equality comparer 
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

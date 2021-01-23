    public class CustomComparer : Comparer<IEnumerable<int>>
    {
        public override int Compare(IEnumerable<int> x, IEnumerable<int> y)
        {            
            var comparisons = x.Zip(y, (a,b) => b.CompareTo(a));
            foreach(var comparision in comparisons)
            {
                if (comparision != 0)
                    return comparision;
            }
            return 0;
        }
    }

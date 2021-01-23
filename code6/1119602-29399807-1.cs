    class Program
    {
        private static void Main(string[] args)
        {
            var h1 = new SortedList<string, int>();
                h1.Add("One", 1);
                h1.Add("Two", 2);
            var h2 = new SortedList<string, int>();
                h2.Add("One", 1);
                h2.Add("Two", 22);
                h2.Add("Three", 3);
            var unDict = h1.Union(h2).Distinct(new SortedListComparer()).ToDictionary(d=>d.Key);
           
            SortedList<string,int>  finSortedList = new SortedList<string,int>((IDictionary<string,int>)unDict,StringComparer.InvariantCultureIgnoreCase);
        }
    }
    class SortedListComparer:EqualityComparer<KeyValuePair<string,int>>
    {
        public override bool Equals(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
        {
            return x.Key == y.Key;  
        }
        public override int GetHashCode(KeyValuePair<string, int> obj)
        {
           return   obj.Key.GetHashCode(); 
        }
    }

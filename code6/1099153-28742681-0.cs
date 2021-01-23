    public class Comparer : IComparer<char>
    {
        public int Compare(Char a, Char b)
        {
           //return positive if a should be higher, return negative if b should be higher
        }
    }
    
    c.OrderBy(c => c, new Comparer()).ForEach(x => Console.WriteLine(x));

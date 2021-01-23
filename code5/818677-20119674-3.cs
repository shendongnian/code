    public static class Extensions
    {
        public static IEnumerable<T> TakeN<T>(this List<T> list, int n)
        {
            for(int i = 0; i < n; i++)
                yield return list[i];
        }
    }
    //Usage:
    List<WordCount> counts = new List<WordCount>();
    //Fill the list with 10000 items and call TakeN()
    IEnumerable<WordCount> smallList = counts.TakeN(20);
    //Or
    counts = counts.TakeN(20).ToList();

    public static class Extensions
    {
        public static bool NotIn<T>(this T item, IList<T> list)
        {
            return !list.Contains(item);
        }
    }
    //Example:
    List<int> listA = new List<int> { 1, 2, 3, 4, 5 };
    List<int> listB = new List<int> { 3, 5, 7, 8 };
    
    var result = listA.Where(x => x.NotIn(listB));
    //Output: 1, 2, 4

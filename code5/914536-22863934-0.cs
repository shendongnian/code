    class Program
    {
        static void Main(string[] args)
        {
            List<int> l1 = new List<int>() { 3, 4 };
            List<int> l2 = new List<int>() { 5, 6 };
            var a = new List<int>() { 1, 2 }.FluentAddRange(l1).FluentAddRange(l2);
        }
    }
    public static class Extensions
    {
        public static List<T> FluentAddRange<T>(this List<T> list, List<T> newList)
        {
            list.AddRange(newList);
            return list;
        }
    }

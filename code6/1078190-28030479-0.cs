    public static class Ext
    {
        public static List<T> LastToFront<T>(this List<T> list)
        {
            list.Insert(0, list.Last());
            list.RemoveAt(list.Count - 1);
            return list;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> myList = new List<int> { 1, 2, 3, 4, 5 };
            myList.LastToFront(); // The result will be { 5, 1, 2, 3, 4 }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> ParentList = new List<List<string>>();
            List<string> ChildList1 = new List<string> { "B1", "B2", "B3" };
            List<string> ChildList2 = new List<string> { "B1", "B3", "B2" };
            List<string> ChildList3 = new List<string> { "B1", "B2" };
            List<string> ChildList4 = new List<string> { "B5", "B3", "B2", "B4" };
            ParentList.Add(ChildList1);
            ParentList.Add(ChildList2);
            ParentList.Add(ChildList3);
            ParentList.Add(ChildList4);
            var result = ParentList.Distinct(new Comparer()).ToList();
        }
    }
    internal class Comparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> list1, List<string> list2)
        {
            return list1.All(x => list2.Contains(x)) && list2.All(x => list1.Contains(x));
        }
        public int GetHashCode(List<string> obj)
        {
            return obj.Count;
        }
    }
